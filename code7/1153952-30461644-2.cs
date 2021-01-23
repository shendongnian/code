    public interface IPersistanceProvider<TValue>
    {
        void Save(string key, TValue value);
        TValue Load(string key);
    }
    public sealed class CustomCache<TValue> : IDisposable
    {
        private readonly TimeSpan _slidingExpirationWindow;
        private readonly IPersistanceProvider<TValue> _persistanceProvider;
        private readonly MemoryCache _cache;
        /// <summary>
        /// A custom cache that writes items out to a IPersistanceProvider when the item is evicted from the cache.
        /// </summary>
        /// <param name="slidingExpirationWindow">The amount of time before the item is automatically evicted if it has not been accessed.</param>
        /// <param name="cacheMemoryLimitMegabytes">The maximum size the cache can be before it starts force evicting items.</param>
        /// <param name="persistanceProvider">The service that will save and load data to a persistent storage.</param>
        public CustomCache(TimeSpan slidingExpirationWindow, int cacheMemoryLimitMegabytes, IPersistanceProvider<TValue> persistanceProvider)
        {
            _slidingExpirationWindow = slidingExpirationWindow;
            _persistanceProvider = persistanceProvider;
            _cache = new MemoryCache("", new NameValueCollection { { "CacheMemoryLimitMegabytes", cacheMemoryLimitMegabytes.ToString("D") } });
        }
        public void SetItem(string key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            if (value == null)
                throw new ArgumentNullException("value");
            SetCacheItem(key, value);
        }
        public TValue GetItem(string key)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            var item = _cache.Get(key);
            if (item == null)
            {
                item = _persistanceProvider.Load(key);
                SetCacheItem(key, item);
            }
            return (TValue)item;
        }
        public void RemoveItem(string key)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            _cache.Remove(key);
        }
        public void Dispose()
        {
            if (_cache != null)
            {
                _cache.Dispose();
            }
        }
        private void SetCacheItem(string key, object value)
        {
            var policy = new CacheItemPolicy();
            policy.RemovedCallback = RemovedCallback;
            policy.SlidingExpiration = _slidingExpirationWindow;
            _cache.Set(key, value, policy);
        }
        private void RemovedCallback(CacheEntryRemovedArguments arguments)
        {
            if (arguments.RemovedReason == CacheEntryRemovedReason.Removed)
                return;
            _persistanceProvider.Save(arguments.CacheItem.Key, (TValue)arguments.CacheItem.Value);
        }
    }
