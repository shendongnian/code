    private class DataAccessTestStub
            {
                public const string DateTimeTicksCacheKey = "GetDateTimeTicks";
    
                ICacheWrapper _cache;
    
                public DataAccessTestStub(ICacheWrapper cache)
                {
                    _cache = cache;
                }
    
                public string GetDateTimeTicks()
                {
                    return _cache.GetFromCache(DateTimeTicksCacheKey, () =>
                    {
                        var result = DateTime.Now.Ticks.ToString();
                        Thread.Sleep(100); // Create some delay
                        return result;
                    });
                }
    
                public string GetDateTimeTicks(TimeSpan timeToLive)
                {
                    return _cache.GetFromCache(DateTimeTicksCacheKey, () =>
                    {
                        var result = DateTime.Now.Ticks.ToString();
                        Thread.Sleep(500); // Create some delay
                        return result;
                    }, timeToLive);
                }
    
                public void ClearDateTimeTicks()
                {
                    _cache.InvalidateCache(DateTimeTicksCacheKey);
                }
    
                public void ClearCache()
                {
                    _cache.ClearCache();
                }
            }
