    public static class CacheManager
    {
        public static Task<T> GetAsync<T>(string cacheKey, Func<Task<T>> factory)
    where T : class
        {
            var result = (T)MemoryCache.Default.Get(cacheKey);
            if (result != null)
            {
                return Task.FromResult(result);
            }
            return RunFactory<T>(cacheKey, factory);
        }
        private static async Task<T> RunFactory<T>(string cacheKey, Func<Task<T>> factory)
            where T : class
        {
            await PurgeOldLocks();
            var cacheLock = _locks.GetOrAdd(cacheKey, (key) => new SemaphoreSlim(1));
            try
            {
                //Wait for anyone currently running the factory.
                await cacheLock.WaitAsync();
                //Check to see if another factory has already ran while we waited.
                var oldResult = (T)MemoryCache.Default.Get(cacheKey);
                if (oldResult != null)
                {
                    return oldResult;
                }
                //Run the factory then cache the result.
                var newResult = await factory();
                MemoryCache.Default.Add(cacheKey, newResult, _myDefaultPolicy);
                return newResult;
            }
            finally
            {
                cacheLock.Release();
            }
        }
        private static async Task PurgeOldLocks()
        {
            try
            {
                //Only one thread can run the purge;
                await _purgeLock.WaitAsync();
                if ((DateTime.UtcNow - _lastPurge).Duration() > MinPurgeFrequency)
                {
                    _lastPurge = DateTime.UtcNow;
                    var locksSnapshot = _locks.ToList();
                    foreach (var kvp in locksSnapshot)
                    {
                        //Try to take the lock but do not wait for it.
                        var waited = await kvp.Value.WaitAsync(0);
                        if (waited)
                        {
                            //We where able to take the lock so remove it from the collection and dispose it.
                            SemaphoreSlim _;
                            _locks.TryRemove(kvp.Key, out _);
                            kvp.Value.Dispose();
                        }
                    }
                }
            }
            finally
            {
                _purgeLock.Release();
            }
        }
        public static TimeSpan MinPurgeFrequency { get; set; } = TimeSpan.FromHours(1);
        private static DateTime _lastPurge = DateTime.MinValue;
        private static readonly SemaphoreSlim _purgeLock = new SemaphoreSlim(1);
        private static readonly ConcurrentDictionary<string, SemaphoreSlim> _locks = new ConcurrentDictionary<string, SemaphoreSlim>();
        private static CacheItemPolicy _myDefaultPolicy = //...
    }
