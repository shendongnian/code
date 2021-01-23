    public class AutoInterningStringConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // CanConvert is not called when a converter is applied directly to a property.
            throw new NotImplementedException("AutoInterningStringConverter should not be used globally");
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var s = reader.TokenType == JsonToken.String ? (string)reader.Value : (string)JToken.Load(reader); // Check is in case the value is a non-string literal such as an integer.
            return String.Intern(s);
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
