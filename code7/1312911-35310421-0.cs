    public class PetConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) { return objectType == typeof(Mammal); }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { throw new NotImplementedException(); }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            if (reader.TokenType == JsonToken.StartArray)
            {
                var li = new List<Mammal>();
                var arr = JArray.Load(reader);
                foreach (JObject obj in arr)
                {
                    if (obj["Drools"] != null)
                    {
                        var k = obj.ToObject<Dog>(serializer);
                        li.Add(k);
                    }
                }
                return li;
            }
            JObject jsonObject = JObject.Load(reader);
            if (jsonObject["Lives"] != null) return jsonObject.ToObject<Cat>(serializer);
            //if (jsonObject["Drools"] != null) return jsonObject.ToObject<Dog>(serializer);
            return null;
        }
    }
