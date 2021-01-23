     public static T GetFromCache<T>(double seconds, string cacheId, Func<T> method) where T : class
            {
                HttpContext ctx = HttpContext.Current;
                object temp = null;
                temp = ctx.Cache[cacheId];
                if (temp == null)
                {
                    temp = method.Invoke();
                    AddToCache(temp as T, seconds, cacheId);
                    return temp as T;
                }
            }
