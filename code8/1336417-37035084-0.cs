    using System;
    using System.Runtime.Caching;
    
    namespace Services.Util
    {
        public class CacheWrapper : ICacheWrapper
        {
            ObjectCache _cache = MemoryCache.Default;
    
            public void ClearCache()
            {
                MemoryCache.Default.Dispose();
                _cache = MemoryCache.Default;
            }
    
            public T GetFromCache<T>(string key, Func<T> missedCacheCall)
            {
                return GetFromCache<T>(key, missedCacheCall, TimeSpan.FromMinutes(5));
            }
    
            public T GetFromCache<T>(string key, Func<T> missedCacheCall, TimeSpan timeToLive)
            {
                var result = _cache.Get(key);
                if (result == null)
                {
                    result = missedCacheCall();
                    if (result != null)
                    {
                        _cache.Set(key, result, new CacheItemPolicy { AbsoluteExpiration = DateTimeOffset.Now.Add(timeToLive) });
                    }
                }
    
                return (T)result;
            }
    
            public void InvalidateCache(string key)
            {
                _cache.Remove(key);
            }
        }
    }
