    using System.Runtime.Caching;
    static partial class MemoryCacheExtensions
    {
        public static Task<T> GetOrCreateLazyAsync<T>(this MemoryCache cache, string key,
            Func<Task<T>> valueFactory, Func<CacheItemPolicy> cacheItemPolicyFactory)
        {
            var lazyTask = (Lazy<Task<T>>)cache.Get(key);
            if (lazyTask != null) return lazyTask.Value.ToAsyncConditional();
            lazyTask = new Lazy<Task<T>>(valueFactory);
            var cacheItem = new CacheItem(key, lazyTask);
            var cacheItemPolicy = cacheItemPolicyFactory?.Invoke();
            var existingCacheItem = cache.AddOrGetExisting(cacheItem, cacheItemPolicy);
            return ((Lazy<Task<T>>)(existingCacheItem?.Value ?? cacheItem.Value)).Value
                .ToAsyncConditional();
        }
        public static Task<T> GetOrCreateLazyAsync<T>(this MemoryCache cache, string key,
            Func<Task<T>> valueFactory, DateTimeOffset absoluteExpiration)
        {
            return cache.GetOrCreateLazyAsync(key, valueFactory, () => new CacheItemPolicy()
            {
                AbsoluteExpiration = absoluteExpiration,
            });
        }
        public static Task<T> GetOrCreateLazyAsync<T>(this MemoryCache cache, string key,
            Func<Task<T>> valueFactory, TimeSpan slidingExpiration)
        {
            return cache.GetOrCreateLazyAsync(key, valueFactory, () => new CacheItemPolicy()
            {
                SlidingExpiration = slidingExpiration,
            });
        }
        private static Task<TResult> ToAsyncConditional<TResult>(this Task<TResult> task)
        {
            if (task.IsCompleted) return task;
            return task.ContinueWith(async t => await t,
                default, TaskContinuationOptions.RunContinuationsAsynchronously,
                TaskScheduler.Default).Unwrap();
        }
    }
