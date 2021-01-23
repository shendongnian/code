    using System.Runtime.Caching;
    MemoryCache cache;
    object o;
    object w; //service result
    
    cache = new MemoryCache("yourCache");
    
    o = cache.Get("MyCacheItem");
