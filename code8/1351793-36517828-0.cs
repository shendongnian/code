    public class Cache<T>:IEnumerable<T>
    {
        private readonly MemoryCache _memoryCache;
        public Cache(string name)
        {
            _memoryCache = new MemoryCache(name);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return _memoryCache.Select(p=>p.Value).OfType<T>().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
