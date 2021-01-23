    public class KeyValueConverter : JsonConverter
    {
        interface IToKeyValuePair
        {
            object ToKeyValuePair();
        }
        struct Pair<TKey, TValue> : IToKeyValuePair
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public object ToKeyValuePair()
            {
                return new KeyValuePair<TKey, TValue>(Key, Value);
            }
        }
        public override bool CanConvert(Type objectType)
        {
            bool isNullable = (Nullable.GetUnderlyingType(objectType) != null);
            Type type = (Nullable.GetUnderlyingType(objectType) ?? objectType);
            return type.IsGenericType
                && type.GetGenericTypeDefinition() == typeof(KeyValuePair<,>);
        }
        public override bool CanWrite { get { return false; } } // Use Json.NET's writer.
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            bool isNullable = (Nullable.GetUnderlyingType(objectType) != null);
            Type type = (Nullable.GetUnderlyingType(objectType) ?? objectType);
            if (isNullable && reader.TokenType == JsonToken.Null)
                return null;
            if (type.IsGenericType
                && type.GetGenericTypeDefinition() == typeof(KeyValuePair<,>))
            {
                var pairType = typeof(Pair<,>).MakeGenericType(type.GetGenericArguments());
                var pair = serializer.Deserialize(reader, pairType);
                if (pair == null)
                    return null;
                return ((IToKeyValuePair)pair).ToKeyValuePair();
            }
            else
            {
                throw new JsonSerializationException("Invalid type: " + objectType);
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
