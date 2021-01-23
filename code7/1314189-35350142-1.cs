    public class NullableTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return Nullable.GetUnderlyingType(objectType) != null;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var underlyingType = Nullable.GetUnderlyingType(objectType);
            if (underlyingType == null)
                throw new JsonSerializationException("Invalid type " + objectType.ToString());
            var token = JToken.Load(reader);
            try
            {
                return token.ToObject(underlyingType, serializer);
            }
            catch (Exception ex)
            {
                // Log the exception somehow
                Debug.WriteLine(ex);
                return null;
            }
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
