    // Warning: bad code!
    public class KeyValuePairs<TValue>
    {
        private object _value;
        public string Key { get; set; }
        public TValue GetValue<TValue>()
        {
            return _value;
        }
        public void Setalue<TValue>(TValue value)
        {
            _value = value;
        }
    }
