    public class AdjustableDictionary<K, V> 
    {
        public K CurrentAdjustment { get; set; }        
        public int Count { get { return _dictionary.Count; } }
        public ICollection<K> Keys { get { return _dictionary.Keys.Select(k => AdjustKey(k)).ToList(); } }
        private IDictionary<K, V> _dictionary;
        private Func<K, K, K> _adjustKey;
        public AdjustableDictionary(Func<K, K, K> keyAdjuster = null)
        {
            _dictionary = new Dictionary<K, V>();
            _adjustKey = keyAdjuster;
        }
        public void Add(K key, V value)
        {
            _dictionary.Add(AdjustKey(key), value);
        }
        public bool ContainsKey(K key)
        {
            return _dictionary.ContainsKey(AdjustKey(key));
        }
        
        public bool Remove(K key)
        {
            return _dictionary.Remove(AdjustKey(key));
        }
        public bool TryGetValue(K key, out V value)
        {
            return _dictionary.TryGetValue(AdjustKey(key), out value);
        }
        public ICollection<V> Values { get { return _dictionary.Values; } }
        public V this[K key] {
            get {
                return _dictionary[AdjustKey(key)];
            }
            set {
                _dictionary[AdjustKey(key)] = value;
            }
        }
        public void Clear()
        {
            _dictionary.Clear();
        }
        private K AdjustKey(K key)
        {
            return _adjustKey != null
                ? _adjustKey(key, CurrentAdjustment)
                : key;
        }
    }
