    public class CustomFloatConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(float);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Float)
            {
                return (float)token;
            }
            if (token.Type == JTokenType.String)
            {
                return float.Parse(token.ToString(), CultureInfo.InvariantCulture);
            }
            if (token.Type == JTokenType.Null || token.Type == JTokenType.Undefined)
            {
                return float.NaN;
            }
            throw new JsonSerializationException("Unexpected token type: " + token.Type);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
