    public interface IPersistanceProvider<TValue>
    {
        void Save(string key, TValue value);
        TValue Load(string key);
    }
    public sealed class CustomCache<TValue> : IDisposable
    {
        private readonly IPersistanceProvider<TValue> _persistanceProvider;
        private readonly MemoryCache _cache;
        public CustomCache(int cacheMemoryLimitMegabytes, IPersistanceProvider<TValue> persistanceProvider)
        {
            _persistanceProvider = persistanceProvider;
            _cache = new MemoryCache("", new NameValueCollection {{"CacheMemoryLimitMegabytes", cacheMemoryLimitMegabytes.ToString("D")}});
        }
        public void SetItem(string key, TValue value)
        {
            if(key == null)
                throw new ArgumentNullException("key");
            if(value == null)
                throw new ArgumentNullException("value");
            SetCacheItem(key, value);
        }
        private void SetCacheItem(string key, object value)
        {
            var policy = new CacheItemPolicy();
            policy.RemovedCallback = RemovedCallback;
            _cache.Set(key, value, policy);
        }
        private void RemovedCallback(CacheEntryRemovedArguments arguments)
        {
            if(arguments.RemovedReason == CacheEntryRemovedReason.Removed)
                return;
            
            _persistanceProvider.Save(arguments.CacheItem.Key, (TValue)arguments.CacheItem.Value);
        }
        public TValue GetItem(string key)
        {
            if(key == null)
                throw new ArgumentNullException("key");
            var item = _cache.Get(key);
            if (item == null)
            {
                item = _persistanceProvider.Load(key);
                SetCacheItem(key, item);
            }
            return (TValue)item;
        }
        public void Dispose()
        {
            if (_cache != null)
            {
                _cache.Dispose();
            }
        }
    }
