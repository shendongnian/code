    public class CacheWithSizeLimit<TKey,TValue>
    {
        private int _cacheSize;
        public CacheWithSizeLimit(int cacheSize = 10000)
        {
            Cache = new ConcurrentDictionary<int, KeyValuePair<TKey, TValue>>();
            _cacheSize = cacheSize;
        }
        private ConcurrentDictionary<int, KeyValuePair<TKey, TValue>> Cache { get; set; }
        public TValue GetCachedValue(TKey inputKey)
        {
            KeyValuePair<TKey,TValue> result;
            var key = inputKey.GetHashCode() % _cacheSize;
            
            Cache.TryGetValue(key, out result);
            if (!IsNullOrEmpty(result.Key) && result.Key.Equals(inputKey))
            {
                return result.Value;
            }
            return default(TValue);
        }
        private bool IsNullOrEmpty<T>(T value)
        {
            return EqualityComparer<T>.Default.Equals(value, default(T));
        }
        public void SetCachedValue(TKey inputKey, TValue inputValue)
        {
            var key = inputKey.GetHashCode() % _cacheSize;
            Cache.AddOrUpdate(key, new KeyValuePair<TKey, TValue>(inputKey, inputValue));
        }
        internal void Clear()
        {
                Cache = new ConcurrentDictionary<int, KeyValuePair<TKey, TValue>>();
        }
    }
