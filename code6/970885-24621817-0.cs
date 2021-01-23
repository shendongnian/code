    class RestrictedCache
    {
        private Cache cache = //...;
        private object _lock = new{};
        public object Get(string key)
        {
            lock(_lock)
            {
                return cache[key];
            }
        }
        public void Set(string key, object value)
        {
            lock(_lock)
            {
                cache[key]=value;
            }
        }
    }
