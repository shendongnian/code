    ObjectCache cache = MemoryCache.Default;
    ...
    var foos = cache.Get("key") as List<Foo>;
    if (foos == null)
    {
        foos = repo.GetFoos();
        cache.Add("key", foos, new CacheItemPolicy
        { 
            AbsoluteExpiration = DateTimeOffset.Now.AddHours(1)
        });
    }
    // do something with `foos`
   
