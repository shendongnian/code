    public static class HelperFunctions
    {
        public static Func<T> Cache<T>(this Func<T> inner, string cacheName)
        {
            return () =>
            {
                if (HttpRuntime.Cache[cacheName] == null)
                {
                    var result = inner();
                    HttpRuntime.Cache.Insert(cacheName, inner(), null, DateTime.Now.AddMinutes(20), new TimeSpan(0, 10, 0));
                    return result;
                }
                return (T)HttpRuntime.Cache[cacheName];
            };
        }
        public static Func<T> OnError<T>(this Func<T> inner, Func<Exception, T> onError)
        {
            return () =>
            {
                try
                {
                    return inner();
                }
                catch (Exception e)
                {
                    return onError(e);
                }
            };
        }
    }
