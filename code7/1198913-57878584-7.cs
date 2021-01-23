    using Microsoft.Extensions.Caching.Memory;
    static partial class MemoryCacheExtensions
    {
        public static Task<T> GetOrCreateLazyAsync<T>(this MemoryCache cache, object key,
            Func<ICacheEntry, Task<T>> factory)
        {
            return cache.GetOrCreate(key, e =>
            {
                return new Lazy<Task<T>>(() => factory(e));
            }).Value.ToAsyncConditional();
        }
        public static Task<T> GetOrCreateLazyAsync<T>(this MemoryCache cache, object key,
            Func<Task<T>> valueFactory, DateTimeOffset absoluteExpiration)
        {
            return cache.GetOrCreateLazyAsync(key, e =>
            {
                e.AbsoluteExpiration = absoluteExpiration;
                return valueFactory();
            });
        }
        public static Task<T> GetOrCreateLazyAsync<T>(this MemoryCache cache, object key,
            Func<Task<T>> valueFactory, TimeSpan slidingExpiration)
        {
            return cache.GetOrCreateLazyAsync(key, e =>
            {
                e.SlidingExpiration = slidingExpiration;
                return valueFactory();
            });
        }
    }
