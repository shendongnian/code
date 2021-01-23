    using Microsoft.Extensions.Caching.Memory;
    static partial class MemoryCacheExtensions
    {
        public static Task<T> GetOrCreateLazyAsync<T>(this MemoryCache cache, string key,
            Func<ICacheEntry, Task<T>> factory)
        {
            return ((Lazy<Task<T>>)cache.Get(key) ?? cache.GetOrCreate(key, e =>
            {
                return new Lazy<Task<T>>(() => factory(e));
            })).Value;
        }
        public static Task<T> GetOrCreateLazyAsync<T>(this MemoryCache cache, string key,
            Func<Task<T>> valueFactory, DateTimeOffset absoluteExpiration)
        {
            return cache.GetOrCreateLazyAsync(key, e =>
            {
                e.AbsoluteExpiration = absoluteExpiration;
                return valueFactory();
            });
        }
        public static Task<T> GetOrCreateLazyAsync<T>(this MemoryCache cache, string key,
            Func<Task<T>> valueFactory, TimeSpan slidingExpiration)
        {
            return cache.GetOrCreateLazyAsync(key, e =>
            {
                e.SlidingExpiration = slidingExpiration;
                return valueFactory();
            });
        }
    }
