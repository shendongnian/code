    /// <summary>
    /// <remarks>The [] operator can not be generic, so we implement it has a getter and a setter</remarks>
    /// </summary>
    class HeterogeneousDictionary
    {
        private readonly Dictionary<HeterogeneousDictionaryKeyBase, object> _dictionary = new Dictionary<HeterogeneousDictionaryKeyBase, object>();
        public void Add<TValue>(HeterogeneousDictionaryKey<TValue> key, TValue value)
        {
            _dictionary.Add(key, value);
        }
        public TValue Get<TValue>(HeterogeneousDictionaryKey<TValue> key)
        {
            return (TValue)_dictionary[key];
        }
        public void Set<TValue>(HeterogeneousDictionaryKey<TValue> key, TValue value)
        {
            _dictionary[key] = value;
        }
        public bool TryGetValue<TValue>(HeterogeneousDictionaryKey<TValue> key, out TValue value)
        {
            object result;
            if (_dictionary.TryGetValue(key, out result) && result is TValue)
            {
                value = (TValue)result;
                return true;
            }
            value = default(TValue);
            return false;
        }
    }
