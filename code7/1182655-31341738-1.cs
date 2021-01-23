    public static T Cache<T>(string key, Func<T> loadFunction, Func<T> errorHandler)
    {
         if (HttpRuntime.Cache[key] == null)
         {
             try
             {
                 T value = loadFunction();
             HttpRuntime.Cache.Insert(key, value , null, DateTime.Now.AddMinutes(20), new TimeSpan(0, 10, 0));
                 return value;
             }
             catch(Exception e)
             {
                 //TODO: Report this
                 return errorHandler();
             }
         }
         else
             return (T)HttpRuntime.Cache[key];
    }
