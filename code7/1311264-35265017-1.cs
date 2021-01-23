    class NullableBoolDeSerializer : JsonConverter
    {
        readonly string[] TrueStrings = { "true", "yes", "1" };
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool?);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string b = (string)reader.Value;
            return b != null ? TrueStrings.Contains(b.ToLower()) : (bool?)null;
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
