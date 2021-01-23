    class MyDictionary<TKey, TValue>
    {
        private readonly Dictionary<TKey, TValue> _dictionary;
        public void Add(TKey key, TValue value)
        {
            _dictionary.Add(key, value);
        }
        public void Clear()
        {
            _dictionary.Clear();
        }
        public bool Remve(TKey key)
        {
            return _dictionary.Remove(key);
        }
