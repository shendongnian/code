    public static class Cached
    {
        private const string _kcountriesKey = "CountriesList";
        private const string _kstatesKey = "StatesList";
        private static readonly object _kcountriesLock = new object();
        private static readonly object _kstatesLock = new object();
        public static List<Country> GetCountriesList()
        {
            List<Country> cacheItem = (List<Country>)HttpContext.Current.Cache[_kcountriesKey];
    
            if (cacheItem == null)
            {
                lock (_kcountriesLock)
                {
                    // Check once more in case it got stored while waiting on the lock
                    cacheItem = (List<Country>)HttpContext.Current.Cache[_kcountriesKey];
                    if (cacheItem == null)    
                    {
                        using (var repo = new Repository())
                        {
                            cacheItem = repo.SelectCountries();
                            HttpContext.Current.Cache.Insert(_kcountriesKey, cacheItem, null, DateTime.Now.AddHours(2), TimeSpan.Zero);
                        }
                    }
                }
            }
    
            return cacheItem;
        }
        // etc.
    }
