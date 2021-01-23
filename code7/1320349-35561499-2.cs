    public static class Cached
    {
        private const string _kcountriesKey = "CountriesList";
        private const string _kstatesKey = "StatesList";
        private static readonly object _kcountriesLock = new object();
        private static readonly object _kstatesLock = new object();
        public static List<Country> GetCountriesList()
        {
            // Assuming SelectCountries() is in fact declared to return List<Country>
            // then you should actually be able to omit the type parameter in the method
            // call and let type inference figure it out. Same thing for the call to
            // _GetCachedData<State>() in the GetStatesList() method.
            return _GetCachedData<Country>(_kcountriesKey, _kcountriesLock, repo => repo.SelectCountries());
        }
        public static List<State> GetStatesList()
        {
            return _GetCachedData<State>(_kstatesKey, _kstatesLock, repo => repo.SelectStates());
        }
        private static List<T> _GetCachedData<T>(string key, object lockObject, Func<Repository, List<T>> selector)
        {
            List<T> cacheItem = (List<T>)HttpContext.Current.Cache[key];
    
            if (cacheItem == null)
            {
                lock (lockObject)
                {
                    // Check once more in case it got stored while waiting on the lock
                    cacheItem = (List<T>)HttpContext.Current.Cache[key];
                    if (cacheItem == null)    
                    {
                        using (var repo = new Repository())
                        {
                            cacheItem = selector(repo);
                            HttpContext.Current.Cache.Insert(key, cacheItem, null, DateTime.Now.AddHours(2), TimeSpan.Zero);
                        }
                    }
                }
            }
    
            return cacheItem;
        }
        // etc.
    }
