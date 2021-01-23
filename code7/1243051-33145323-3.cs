     private void InsertCache(string key, object value)
            {
                // Setting Cache Item Policy
                var policy = new CacheItemPolicy
                {
                    SlidingExpiration = new TimeSpan(0, 0, CacheTimeOut)
                };
    
                // sliding Expiration Timeout in Seconds
                ObjectCache cache = MemoryCache.Default;
    
                // Set the key,value in the cache
                cache.Set(key, value, policy);
            }
