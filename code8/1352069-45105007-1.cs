    public interface IMultiMap<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
    {
        IEnumerable<TValue> this[TKey key] { get; set; }
        int Count { get; }
        IEnumerable<TKey> Keys { get; }
        IEnumerable<TValue> Values { get; }
        void Add(TKey key, TValue value);
        void Clear();
        bool Contains(TKey Key, TValue value);
        bool Contains(KeyValuePair<TKey, TValue> item);
        bool ContainsKey(TKey key);
        bool Remove(KeyValuePair<TKey, TValue> item);
        bool Remove(TKey key);
        bool Remove(TKey key, TValue value);
        bool TryGetValue(TKey key, out IEnumerable<TValue> value);
    }
    public class MultiMap<TKey, TValue> : IMultiMap<TKey, TValue>
    {
        private SortedDictionary<TKey, SortedSet<TValue>> _Items;
        public MultiMap()
        {
            _Items = new SortedDictionary<TKey, SortedSet<TValue>>();
        }
        public IEnumerable<TValue> this[TKey key]
        {
            get
            {
                return _Items[key];
            }
            set
            {
                _Items[key] = new SortedSet<TValue>(value);
            }
        }
        public int Count
        {
            get
            {
                return _Items.SelectMany(kvp => kvp.Value).Count();
            }
        }
        public IEnumerable<TKey> Keys
        {
            get
            {
                return _Items.Keys;
            }
        }
        public IEnumerable<TValue> Values
        {
            get
            {
                return _Items.SelectMany(kvp => kvp.Value);
            }
        }
        public void Add(TKey key, TValue value)
        {
            if (!_Items.ContainsKey(key))
                _Items.Add(key, new SortedSet<TValue>());
            _Items[key].Add(value);
        }
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }
        public void Clear()
        {
            _Items.Clear();
        }
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return Contains(item.Key, item.Value);
        }
        public bool Contains(TKey key, TValue value)
        {
            return _Items.ContainsKey(key) && _Items[key].Contains(value);
        }
        public bool ContainsKey(TKey key)
        {
            return _Items.ContainsKey(key);
        }
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {            
            return _Items.SelectMany(kvp => kvp.Value.Select(v => new KeyValuePair<TKey, TValue>(kvp.Key, v))).GetEnumerator();            
        }
        public bool Remove(TKey key)
        {
            return _Items.Remove(key);
        }
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key, item.Value);
        }
        public bool Remove(TKey key, TValue value)
        {
            if (!_Items.ContainsKey(key))
                return false;
            return _Items[key].Remove(value);
        }
        public bool TryGetValue(TKey key, out IEnumerable<TValue> value)
        {
            bool isPresent = _Items.ContainsKey(key);
            value = isPresent ? _Items[key] : null;
            return isPresent;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
