    public class ReplacingStringConverter : JsonConverter
    {
        readonly string oldValue;
        readonly string newValue;
        public ReplacingStringConverter(string oldValue, string newValue)
        {
            if (oldValue == null)
                throw new ArgumentNullException("oldValue");
            if (string.IsNullOrEmpty(oldValue))
                throw new ArgumentException("string.IsNullOrEmpty(oldValue)");
            this.oldValue = oldValue;
            this.newValue = newValue;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var s = (string)JToken.Load(reader);
            return s.Replace(oldValue, newValue);
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
