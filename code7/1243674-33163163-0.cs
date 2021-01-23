    public class IgnoreArrayTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsArray && objectType.GetArrayRank() == 1 && objectType.HasElementType;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!CanConvert(objectType))
                throw new JsonSerializationException(string.Format("Invalid type \"{0}\"", objectType));
            if (reader.TokenType == JsonToken.Null)
                return null;
            var token = JToken.Load(reader);
            var itemType = objectType.GetElementType();
            return ToArray(token, itemType, serializer);
        }
        private static object ToArray(JToken token, Type itemType, JsonSerializer serializer)
        {
            if (token == null || token.Type == JTokenType.Null)
                return null;
            else if (token.Type == JTokenType.Array)
            {
                var listType = typeof(List<>).MakeGenericType(itemType);
                var list = (ICollection)token.ToObject(listType, serializer);
                var array = Array.CreateInstance(itemType, list.Count);
                list.CopyTo(array, 0);
                return array;
            }
            else if (token.Type == JTokenType.Object)
            {
                var values = token["$values"];
                if (values == null)
                    return null;
                return ToArray(values, itemType, serializer);
            }
            else
            {
                throw new JsonSerializationException("Unknown token type: " + token.ToString());
            }
        }
        public override bool CanWrite { get { return false; } }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
