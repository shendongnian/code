    public class NumberConverter : JsonConverter
    {
        private readonly Type[] _typesNotToReadAsString = { typeof(float), typeof(float?) };
        public override bool CanConvert(Type objectType)
        {
            return _typesNotToReadAsString.Any(t => t.IsAssignableFrom(objectType));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (_typesNotToReadAsString.Contains(objectType) && token.Type == JTokenType.String)
            {
                string exceptionString = string.Format("Won't parse string as {0}", objectType.FullName);
                throw new JsonSerializationException(exceptionString);
            }
            return token.ToObject(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanWrite
        {
            get { return false; }
        }
    }
