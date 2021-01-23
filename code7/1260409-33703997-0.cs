    public class MyMemoryCache
    {
        private readonly ObjectCache _cache;
        public MyMemoryCache()
        {
            _cache = MemoryCache.Default;
        }
        /// <summary>
        /// Get an object from cache
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public object Get(string cacheKey)
        {
            return _cache.Get(cacheKey);
        }
        /// <summary>
        /// check if the object is available in the cache
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public bool Contains(string cacheKey)
        {
            return _cache.Contains(cacheKey);
        }
        /// <summary>
        /// Add an objct in to the cache
        /// </summary>
        /// <param name="objectToBeChached"></param>
        /// <param name="cacheKey"></param>
        public void Add(string cacheKey, object objectToBeChached)
        {
            var cacheItemPolicy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddMinutes(5.0) };
            _cache.Add(cacheKey, objectToBeChached, cacheItemPolicy);
        }
    }
