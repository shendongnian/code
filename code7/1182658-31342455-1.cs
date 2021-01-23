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
    public static class Employees
    {
        public static int CurrentEmployees()
        {
            return (new Func<int>(() => Employee.Load().Count(x => x.DateFinished == null && !x.Contractor && x.DateStarted < DateTime.Now)))
                .Cache("CurrentEmployees")
                .OnError(e => -1) 
                ();//TODO: log?
        }
    }
