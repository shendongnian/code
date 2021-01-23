    public class LiteralStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object value = serializer.Deserialize(reader);
            string value2 = JsonConvert.SerializeObject(value);
            return value2;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            string str = (string)value;
            writer.WriteRawValue(str);
        }
    }
