    You can write a [`JsonConverter`](http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonConverter.htm) for this purpose that loads the relevant portion of JSON into a [`JObject`](http://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_JObject.htm), then checks to see whether the object looks like one from the old data model, or the new.  If the JSON looks old, map fields as necessary using [Linq to JSON](http://www.newtonsoft.com/json/help/html/QueryJson.htm).  If the JSON object looks new, you can just [populate your `LeaseOwner`](http://www.newtonsoft.com/json/help/html/PopulateObject.htm) with it.
    Since you are setting `PreserveReferencesHandling = PreserveReferencesHandling.Objects` the converter will need to handle the `"$ref"` properties manually:
        public class OwnerToLeaseOwnerConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return typeof(LeaseOwner).IsAssignableFrom(objectType);
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null)
                    return null;
                var item = JObject.Load(reader);
                if (item["$ref"] != null)
                {
                    var previous = serializer.ReferenceResolver.ResolveReference(serializer, (string)item["$ref"]);
                    if (previous is LeaseOwner)
                        return previous;
                    else if (previous is Owner)
                    {
                        var leaseOwner = serializer.DefaultCreate<LeaseOwner>(objectType, existingValue);
                        leaseOwner.Owner = (Owner)previous;
                        return leaseOwner;
                    }
                    else
                    {
                        throw new JsonSerializationException("Invalid type of previous object: " + previous);
                    }
                }
                else
                {
                    var leaseOwner = serializer.DefaultCreate<LeaseOwner>(objectType, existingValue);
                    if (item["Name"] != null)
                    {
                        // Convert from Owner to LeaseOwner.  If $id is present, this stores the reference mapping in the reference table for us.
                        leaseOwner.Owner = item.ToObject<Owner>(serializer);
                    }
                    else
                    {
                        // PopulateObject.  If $id is present, this stores the reference mapping in the reference table for us.
                        item.PopulateObject(leaseOwner, serializer);
                    }
                    return leaseOwner;
                }
            }
            public override bool CanWrite { get { return false; } }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
