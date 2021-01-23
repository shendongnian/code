    public class Json_34159840
    {        
        public static void CollectionFails()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new ListItemConverter() }
            };
            var coll = new ListItemCollection();
            coll.Add(new ListItem("item one", "1"));
            coll.Add(new ListItem("item two", "2"));
            coll.Add(new ListItem("item three", "3"));
            coll.Add(new ListItem("item four", "4"));
            coll.Add(new ListItem("item five", "5"));
            var aList = JsonConvert.SerializeObject(coll);
            Console.WriteLine(aList);
        }
    }
    public class ListItemConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var item = (ListItem)value;
            writer.WriteStartObject();
            writer.WritePropertyName("Text");
            writer.WriteValue(item.Text);
            writer.WritePropertyName("Value");
            writer.WriteValue(item.Value);
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (ListItem);
        }
    }
