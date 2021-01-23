    // My custom implementation that you may want to change
    public override void OnInvoke(MethodInterceptionArgs args)
            {
                // Fetch standard Cache
                var cache = MemoryCache.Default;
                
                // Fetch Cache Key using the Method arguments
                string cacheKey = GetCacheKey(args); // Code pasted below
    
                var cacheValue = cache.Get(cacheKey);
    
                if (cacheValue != null)
                {
                    args.ReturnValue = cacheValue;
                    return;
                }
                ReloadCache(cacheKey, args);
            }
