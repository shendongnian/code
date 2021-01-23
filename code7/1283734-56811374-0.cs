    public interface IMyMemoryCache : IMemoryCache
    {
        void Reset();
    }
    public class MyMemoryCache: IMyMemoryCache
    {
        IMemoryCache _memoryCache;
    
        public MyMemoryCache()
        {
            Reset();
        }
        public void Dispose()
        {
            _memoryCache.Dispose();
        }
    
        public bool TryGetValue(object key, out object value)
        {
            return _memoryCache.TryGetValue(key, out value);
        }
    
        public ICacheEntry CreateEntry(object key)
        {
            return _memoryCache.CreateEntry(key);
        }
    
        public void Remove(object key)
        {
            _memoryCache.Remove(key);
        }
    
        public void Reset()
        {
            _memoryCache = new MemoryCache(new MemoryCacheOptions());
        }
    }
