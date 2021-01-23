    public NAConverter: JsonConverter
    {
        public override bool CanConvert(Type t) { return t == typeof(string); }
        public override ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            ...
        }
    }
