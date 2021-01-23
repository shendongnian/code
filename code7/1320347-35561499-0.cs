    public static class Cached
    {
        private const string _kcountries = "CountriesList";
        private const string _kstates = "StatesList";
        public static List<Country> GetCountriesList()
        {
            List<Country> cacheItem = (List<Country>)HttpContext.Current.Cache[_kcountries];
    
            if (cacheItem == null)
            {
                lock (_kcountries)
                {
                    // Check once more in case it got stored while waiting on the lock
                    cacheItem = (List<Country>)HttpContext.Current.Cache[_kcountries];
                    if (cacheItem == null)    
                    {
                        using (var repo = new Repository())
                        {
                            cacheItem = repo.SelectCountries();
                            HttpContext.Current.Cache.Insert(_kcountries, cacheItem, null, DateTime.Now.AddHours(2), TimeSpan.Zero);
                        }
                    }
                }
            }
    
            return cacheItem;
        }
    
        public static List<State> GetStatesList()
        {
            // Same as above, except using _kstates instead of _kcountries
        }
    }
