    // Get
    var value = this.HttpContext.Cache["MyKeyName"];
    // Set
    this.HttpContext.Cache.Insert(
        "MyKeyName", 
        value, 
        null, 
        DateTime.Now.AddMinutes(5), 
        System.Web.Caching.Cache.NoSlidingExpiration,
        System.Web.Caching.CacheItemPriority.NotRemovable,
        null);
