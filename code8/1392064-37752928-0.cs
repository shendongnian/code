    public class OrderedDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _innerDictionary = new Dictionary<TKey, TValue>();
        private List<TKey> _keys = new List<TKey>();
        public TValue this[TKey key]
        {
            get
            {
                return _innerDictionary[key];
            }
            set
            {
                if(!_innerDictionary.ContainsKey(key))
                {
                    _keys.Add(key);
                }
                _innerDictionary[key] = value;
            }
        }
        public TValue this[int index]
        {
            get
            {
                return _innerDictionary[_keys[index]];
            }
            set
            {
                _innerDictionary[_keys[index]] = value;
            }
        }        
        public void Add(TKey key, TValue value)
        {
            _innerDictionary.Add(key, value);
            _keys.Add(key);
        }
        public void Clear()
        {
            _innerDictionary.Clear();
            _keys.Clear();
        }
        public bool Remove(TKey key)
        {
            if (_innerDictionary.Remove(key))
            {
                _keys.Remove(key);
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
