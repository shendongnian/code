    class NullableBoolListDeSerializer : JsonConverter
    {
        readonly string[] TrueStrings = { "true", "yes", "1" };
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<bool?>);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return JArray.Load(reader)
                .Children<JValue>()
                .Select(jv =>
                {
                    string b = (string)jv;
                    return b != null ? TrueStrings.Contains(b.ToLower()) : (bool?)null;
                })
                .ToList();
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
