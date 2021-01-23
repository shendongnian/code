    class IgnoringConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteNull();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return null;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ClassToIgnore);
        }
    }
