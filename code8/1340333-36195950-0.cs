    public IList<Gender> GetGenders()
    {
        const string cacheKey = "MyApp_GendersKey";
        if (HttpContext.Current.Cache.Get(cacheKey) == null)
        {
            lock (HttpContext.Current.Cache)
            {
                HttpContext.Current.Cache.Insert(
                    cacheKey,
                     _myservice.GetGenders(),
                    null,
                    DateTime.Now.AddHours(1),
                    System.Web.Caching.Cache.NoSlidingExpiration
                    );
            }
        }
        return (List<Gender>)HttpContext.Current.Cache.Get(cacheKey);
    }
