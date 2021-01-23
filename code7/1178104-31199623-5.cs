    public class ServerCache : DatabaseAccessor {
        private object CachedResources;
    
        private static readonly ServerCache instance;
    
        private ServerCache(){ /* private ctor to prevent instances from beeing createt anywhere but in this class */ }
    
        private static ServerCache Instance 
        {
            get
            {
                if(instance==null)
                   instance = new ServerCache();
                return instance;
            }
        }
    
        public object GetFromCacheOrGetFresh(...) {...}
        public void InvalidateCache(...) {...}
    }
