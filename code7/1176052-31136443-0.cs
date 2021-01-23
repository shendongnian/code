    public static class CacheStore
    {
        private static readonly string _keyMySharedFlag = "shared.flag";
        private static readonly object _lockMySharedFlag = new object();
        public static bool MySharedFlag
        {
            get
            {
                var cachedFlag = (bool?)MemoryCache.Default.Get(_keyMySharedFlag);
                if (cachedFlag != null)
                    return cachedFlag.Value;
                lock (_lockMySharedFlag)
                {
                    // Confirm no other threads wrote to cache while we waited
                    cachedFlag = (bool?)MemoryCache.Default.Get(_keyMySharedFlag);
                    if (cachedFlag != null)
                        return cachedFlag.Value;
                    bool? newFlag = true; // Set to your database value
                    var cachePolicy = new CacheItemPolicy();
                    cachePolicy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5); // 5 minutes
                    MemoryCache.Default.Set(_keyMySharedFlag, newFlag, cachePolicy);
                    return newFlag.Value;
                }
            }
        }
    }
