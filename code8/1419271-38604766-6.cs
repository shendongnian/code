    public class CustomOutputCacheProvider : OutputCacheProvider
    {
        public override object Add(string key, object entry, DateTime utcExpiry)
        {
            // Determine if in session.
            bool isInSession = true;
            if (isInSession)
            {
                return null;
            }
            // Do the same custom caching as you did in your 
            // CustomMemoryCache object
            var result = HttpContext.Current.Cache.Get(key);
            if (result != null)
            {
                return result;
            }
            HttpContext.Current.Cache.Add(key, entry, null, utcExpiry,
                System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
            return entry;
        }
        public override object Get(string key)
        {
            return HttpContext.Current.Cache.Get(key);
        }
        public override void Remove(string key)
        {
            HttpContext.Current.Cache.Remove(key);
        }
        public override void Set(string key, object entry, DateTime utcExpiry)
        {
            HttpContext.Current.Cache.Add(key, entry, null, utcExpiry,
                System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
        }
    }
