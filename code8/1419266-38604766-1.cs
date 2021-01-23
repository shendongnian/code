    public class SessionBasedCacheProvider : OutputCacheProvider
    {
        public override object Get(string key)
        {
            return null; // Do not cache.
        }
        public override object Add(string key, object entry, DateTime utcExpiry)
        {
            // Basically let it "fall through" since we don't want any caching.
            return entry;
        }
        public override void Set(string key, object entry, DateTime utcExpiry)
        {
            // Basically let it "fall through" since we don't want any caching.            
        }
        public override void Remove(string key)
        {
            // Basically let it "fall through" since we don't want any caching.
        }
    }
