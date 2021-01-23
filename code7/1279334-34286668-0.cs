    MemoryCache memCache = MemoryCache.Default;
    memCache.Add(<mykey>, <myvalue>,
              new CacheItemPolicy()
              {
                AbsoluteExpiration = DateTimeOffset.Now.Add(TimeSpan.FromMinutes(_expireminutes)),
                SlidingExpiration = new TimeSpan(0, 0, 0)
              }
              );
