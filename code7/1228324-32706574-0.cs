    static void Main(string[] args)
    {
        var policy = new CacheItemPolicy
        {
            RemovedCallback = RemovedCallback,
            SlidingExpiration = TimeSpan.FromMinutes(5)
        };
        Stream myStream = GetMyStream();
        MemoryCache.Default.Add("myStream", myStream, policy);
    }
    private static void RemovedCallback(CacheEntryRemovedArguments arg)
    {
        if (arg.RemovedReason == CacheEntryRemovedReason.Evicted)
        {
            var item = arg.CacheItem as IDisposable;
            if(item != null)
                item.Dispose();
        }
    }
