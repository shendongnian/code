    public class AspNetCacheService : ICacheService
        {
            private readonly Cache _aspnetCache;
            public AspNetCacheService()
            {
                if (HttpContext.Current != null)
                {
                    _aspnetCache = HttpContext.Current.Cache;
                }
            }
            public Object Get(String key)
            {
                return _aspnetCache[key];
            }
            public void Set(String key, Object data)
            {
                _aspnetCache[key] = data;
            }
            public object this[String name]
            {
                get { return _aspnetCache[name]; }
                set { _aspnetCache[name] = value; }
            }
            
        }
