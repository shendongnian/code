    public class ByteArrayConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(byte[]);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var token = JToken.Load(reader);
            if (token == null)
                return null;
            switch (token.Type)
            {
                case JTokenType.Null:
                    return null;
                case JTokenType.String:
                    return Convert.FromBase64String((string)token);
                case JTokenType.Object:
                    {
                        var value = (string)token["$value"];
                        return value == null ? null : Convert.FromBase64String(value);
                    }
                default:
                    throw new JsonSerializationException("Unknown byte array format");
            }
        }
        public override bool CanWrite { get { return false; } } // Use the default implementation for serialization, which is not broken.
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
