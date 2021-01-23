    public class CacheTracker : ICacheTracker
    {
        private readonly IList<ICacheManager> _cacheList;
        public CacheTracker()
        {
            this._cacheList = new List<ICacheManager>();
        }
        public void AddCache(ICacheManager cache)
        {
            this._cacheList.Add(cache);
        }
        public IReadOnlyList<ICacheManager> GetCaches(Type cacheType)
        {
            var caches =
                            from cache in _cacheList
                            where
                                cache.GetType().GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == cacheType) &&
                                cache.GetType().IsClass
                            select cache;
            return caches
                .ToList()
                .AsReadOnly();
        }
    }
