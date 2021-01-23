            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
                scan.LookForRegistries();
            });
        }
    }
    public class MemoryCacheFake : IMemoryCache
    {
        public ICacheEntry CreateEntry(object key)
        {
            return new CacheEntryFake { Key = key };
        }
        public void Dispose()
        {
        }
        public void Remove(object key)
        {
        }
        public bool TryGetValue(object key, out object value)
        {
            value = null;
            return false;
        }
    }
    public class CacheEntryFake : ICacheEntry
    {
        public object Key {get; set;}
        public object Value { get; set; }
        public DateTimeOffset? AbsoluteExpiration { get; set; }
        public TimeSpan? AbsoluteExpirationRelativeToNow { get; set; }
        public TimeSpan? SlidingExpiration { get; set; }
        public IList<IChangeToken> ExpirationTokens { get; set; }
        public IList<PostEvictionCallbackRegistration> PostEvictionCallbacks { get; set; }
        public CacheItemPriority Priority { get; set; }
        public long? Size { get; set; }
        public void Dispose()
        {
        }
    }
