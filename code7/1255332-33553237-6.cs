    public class DictionaryToDictionaryListConverter<TKey, TValue> : JsonConverter 
    {
        class DictionaryDTO : Dictionary<TKey, TValue>
        {
            public DictionaryDTO(KeyValuePair<TKey, TValue> pair) : base(1) { Add(pair.Key, pair.Value); }
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof(IDictionary<TKey, TValue>).IsAssignableFrom(objectType) && objectType != typeof(DictionaryDTO);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            var token = JToken.Load(reader);
            var dict = (IDictionary<TKey, TValue>)(existingValue as IDictionary<TKey, TValue> ?? serializer.ContractResolver.ResolveContract(objectType).DefaultCreator());
            if (token.Type == JTokenType.Array)
            {
                foreach (var item in token)
                    using (var subReader = item.CreateReader())
                        serializer.Populate(subReader, dict);
            }
            else if (token.Type == JTokenType.Object)
            {
                using (var subReader = token.CreateReader())
                    serializer.Populate(subReader, dict);
            }
            return dict;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dict = (IDictionary<TKey, TValue>)value;
            // Prevent infinite recursion of converters by using DictionaryDTO
            serializer.Serialize(writer, dict.Select(p => new DictionaryDTO(p)));
        }
    }
