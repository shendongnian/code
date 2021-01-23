    public class FooConverter : JsonConverter
    {
        // Declared as abstract in JsonConverter so must be overridden
        public override bool CanConvert(Type objectType) { return true; }
        // Declared as abstract in JsonConverter so must be overridden
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            return token.Type == JToken.Array ? token.ToObject<Foo[]>() : new Foo[] { token.ToObject<Foo>() };
        }
    }
