    public sealed class RawDataJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var tokenReader = reader as JTokenReader;
            var data = tokenReader.CurrentToken.ToString(Formatting.None);
            return data;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteToken(JsonToken.Raw, value);
        }
    }
