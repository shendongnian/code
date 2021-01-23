    public class KeyValuePairs<TValue>
    {
        public KeyValuePairs(string key, TValue value)
        {
            _key = key;
            Value = value;
        }
        private readonly string _key;
        public string Key { get { return _key; } }
        public TValue Value { get; set; }
    }
