    public static class Locator
    {
        private static Dictionary<Type, Lazy<object>> _cache = new Dictionary<Type, Lazy<object>>();
    
        public static void Register<TService, TProvider>()
            where TService : TProvider
            where TProvider : new()
        {
            _cache.Add(typeof(TService), new Lazy<object>(() => new TProvider()));
        }
        
        public static TService GetInstance<TService>()
        {
            return (TService)_cache[typeof(TService)].Value;
        }
    }
