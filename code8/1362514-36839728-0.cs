    lock (string.Intern(id))
    {
        var item = cache.GetCachedItem(id);
        if (item != null)
        {
            return item.Value;
        }
        cache.Add(id, this.CreateItem(id), new CacheItemPolicy
        {
            SlidingExpiration = TimeSpan.FromMinutes(20)
        });
       return /* some value, this line was absent in the original code. */;
    }
