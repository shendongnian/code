    public class DictionaryToDictionaryListConverter<TKey, TValue> : JsonConverter 
    {
        [ThreadStatic]
        static bool disabled;
        // Disables the converter in a thread-safe manner.
        bool Disabled { get { return disabled; } set { disabled = value; } }
        public override bool CanWrite { get { return !Disabled; } }
        public override bool CanRead { get { return !Disabled; } }
        public override bool CanConvert(Type objectType)
        {
            if (Disabled)
                return false;
            return typeof(IDictionary<TKey, TValue>).IsAssignableFrom(objectType);
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
            // Prevent infinite recursion of converters
            using (new PushValue<bool>(true, () => Disabled, val => Disabled = val))
            {
                serializer.Serialize(writer, dict.Select(p => new[] { p }.ToDictionary(p2 => p2.Key, p2 => p2.Value)));
            }
        }
    }
    public struct PushValue<T> : IDisposable
    {
        Action<T> setValue;
        T oldValue;
        public PushValue(T value, Func<T> getValue, Action<T> setValue)
        {
            if (getValue == null || setValue == null)
                throw new ArgumentNullException();
            this.setValue = setValue;
            this.oldValue = getValue();
            setValue(value);
        }
        // By using a disposable struct we avoid the overhead of allocating and freeing an instance of a finalizable class.
        public void Dispose()
        {
            if (setValue != null)
                setValue(oldValue);
        }
    }
