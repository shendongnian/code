    // Setup cache
    SmartInstance<CacheDetails> cacheDetails;
     
    this.For<System.Runtime.Caching.ObjectCache>()
        .Use(s => System.Runtime.Caching.MemoryCache.Default);
     
    this.For<ICacheProvider<ISiteMap>>().Use<RuntimeCacheProvider<ISiteMap>>();
     
    var cacheDependency =
        this.For<ICacheDependency>().Use<RuntimeFileCacheDependency>()
            .Ctor<string>("fileName").Is(absoluteFileName);
     
    cacheDetails =
        this.For<ICacheDetails>().Use<CacheDetails>()
            .Ctor<TimeSpan>("absoluteCacheExpiration").Is(absoluteCacheExpiration)
            .Ctor<TimeSpan>("slidingCacheExpiration").Is(TimeSpan.MinValue)
            .Ctor<ICacheDependency>().Is(cacheDependency);
    
