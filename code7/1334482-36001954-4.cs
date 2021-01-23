    public Task<T> GetAsync<T>(string cacheKey, Func<Task<T>> factory)
        where T : class
    {
        var result = (T)MemoryCache.Default.Get(cacheKey);
        if(result != null)
        {
            return Task.FromResult(result);
        }
    
        return RunFactory<T>(cacheKey, factory);
    }
    private async Task<T> RunFactory<T>(string cacheKey, Func<Task<T>> factory)
        where T : class
    {
        var cacheLock = _locks.GetOrAdd(cacheKey, (key) => new SemaphoreSlim(1));
        try
        {
            //Wait for anyone currently running the factory.
            await cacheLock.WaitAsync();
            //Check to see if another factory has already ran while we waited.
            var oldResult = (T)MemoryCache.Default.Get(cacheKey);
            if(oldResult != null)
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
    //Be careful of potential memory leaks with this if you use a lot of keys.
    private readonly ConcurrentDictionary<string, SemaphoreSlim> _locks = new ConcurrentDictionary<string, SemaphoreSlim>();
    private CacheItemPolicy _myDefaultPolicy = //...
