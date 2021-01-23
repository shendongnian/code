    class RawJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(string));
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // write value directly to output; assumes string is already JSON
            writer.WriteRawValue((string)value);  
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // convert parsed JSON back to string
            return JToken.Load(reader).ToString(Formatting.None);  
        }
    }
