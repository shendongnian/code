    public static class CacheProviderExtensions
    {
        public static T Get<T>(this ICacheProvider cacheProvider, string key);
        public static bool Set<T>(this ICacheProvider cacheProvider, string key, 
          T value, TimeSpan expiration);
    }
