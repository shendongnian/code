    public class CacheSingleton
    {
        private static readonly Lazy<CacheSingleton> Lazy =
            new Lazy<CacheSingleton>(() => new CacheSingleton());
        public static CacheSingleton Instance
        {
            get { return Lazy.Value; }
        }
        private CacheSingleton()
        {
            _cache = MemoryCache.Default;
        }
        private readonly ObjectCache _cache;
        public object Get(string key)
        {
            var contents = _cache[key];
            return contents;
        }
        public void Add(string key, object value, bool useSlidingExpiration = true, int minutesUntilExpiration = 15)
        {
            if (value == null || String.IsNullOrWhiteSpace(key))
            {
                return;
            }
            var policy = new CacheItemPolicy();
            if (useSlidingExpiration)
            {
                policy.SlidingExpiration = new TimeSpan(0, minutesUntilExpiration, 0);
            }
            else
            {
                policy.AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(minutesUntilExpiration);
            }
            _cache.Set(key, value, policy);
        }
        public void Remove(string key)
        {
            if (_cache.Contains(key))
            {
                _cache.Remove(key);
            }
        }
    }
