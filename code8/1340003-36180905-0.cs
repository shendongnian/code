    public interface IServerSideMyInformationCache
    {
        void SetMyObject(string key, MyObject myobj);
        MyObject GetMyObject(string key);
        void RemoveMyObject(string key);
    }
	
    public class ServerSideMyInformationMemoryCache : IServerSideMyInformationCache
    {
        public const string CacheKeyPrefix = "ServerSideMyInformationMemoryCachePrefixKey";
        public void SetMyObject(string key, MyObject myobj)
        {
			/* not shown...custom configuration to house the setting */
            CachingSettingsConfigurationSection settings = CachingSettingsConfigurationRetriever.GetCachingSettings();
            ObjectCache cache = MemoryCache.Default;
            CacheItemPolicy policy = new CacheItemPolicy { SlidingExpiration = new TimeSpan(0, settings.MyObjectCacheMinutes, 0), Priority = CacheItemPriority.NotRemovable };
            cache.Set(this.GetFullCacheKey(key), myobj, policy);
        }
        public MyObject GetMyObject(string key)
        {
            MyObject returnItem = null;
            ObjectCache cache = MemoryCache.Default;
            object value = cache.Get(this.GetFullCacheKey(key));
            if (null != value)
            {
                returnItem = value as MyObject;
            }
            return returnItem;
        }
        public void RemoveMyObject(string key)
        {
            string cacheKey = this.GetFullCacheKey(key);
            ObjectCache cache = MemoryCache.Default;
            if (null != cache)
            {
                if (cache.Contains(cacheKey))
                {
                    cache.Remove(cacheKey);
                }
            }
        }
        private string GetFullCacheKey(string key)
        {
            string returnValue = CacheKeyPrefix + key;
            return returnValue;
        }
    }	
	
	
    public class ServerSideMyInformationSystemWebCachingCache : IServerSideMyInformationCache
    {
        public const string CacheKeyPrefix = "ServerSideMyInformationSystemWebCachingCachePrefixKey";
        public void SetMyObject(string key, MyObject myobj)
        {
            string cacheKey = this.GetFullCacheKey(key);
            if (null != myobj)
            {
                if (null == System.Web.HttpRuntime.Cache[cacheKey])
                {
					/* not shown...custom configuration to house the setting */
                    CachingSettingsConfigurationSection settings = CachingSettingsConfigurationRetriever.GetCachingSettings();
                    System.Web.HttpRuntime.Cache.Insert(
                        cacheKey, 
                        myobj,
                        null, 
                        System.Web.Caching.Cache.NoAbsoluteExpiration,
                        new TimeSpan(0, settings.MyObjectCacheMinutes, 0),
                        System.Web.Caching.CacheItemPriority.NotRemovable, 
                        null);
                }
                else
                {
                    System.Web.HttpRuntime.Cache[cacheKey] = myobj;
                }
            }
        }
        public MyObject GetMyObject(string key)
        {
            MyObject returnItem = null;
            string cacheKey = this.GetFullCacheKey(key);
            if (null != System.Web.HttpRuntime.Cache[cacheKey])
            {
                returnItem = System.Web.HttpRuntime.Cache[cacheKey] as MyObject;
            }
            return returnItem;
        }
        public void RemoveMyObject(string key)
        {
            string cacheKey = this.GetFullCacheKey(key);
            if (null != System.Web.HttpRuntime.Cache[cacheKey])
            {
                System.Web.HttpRuntime.Cache.Remove(cacheKey);
            }
        }
        private string GetFullCacheKey(string key)
        {
            string returnValue = CacheKeyPrefix + key;
            return returnValue;
        }
    }	
	
	/* the crappiest of factories, but shows the point */
    public static class ServerSideMyInformationCacheFactory
    {
        public static IServerSideMyInformationCache GetAIServerSideMyInformationCache()
        {
            return new ServerSideMyInformationMemoryCache();
            ////return new ServerSideMyInformationSystemWebCachingCache();
        }
    }	
	
