    using System.Runtime.Caching;
    public class CacheManager
    {
            private static MemoryCache _cache = MemoryCache.Default;
    
            public static void AddToCache<T>(string key, T value)
            {
                _cache[key] = value;
            }
    
            public static T GetFromCache<T>(string key)
            {
                return (T)_cache[key];
            }
    
            public static void RemoveFromCache(string key)
            {
                _cache.Remove(key);
            }
    }
