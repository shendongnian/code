    public static T Cache<T>(string key, Func<T> LoadFunction)
    {
         if (HttpRuntime.Cache[key] == null)
         {
             try
             {
                 T value = LoadFunction();
                 HttpRuntime.Cache.Insert(key, value , null, DateTime.Now.AddMinutes(20), new TimeSpan(0, 10, 0));
    
                 return value;
             }
             catch(Exception e)
             {
                 //TODO: Report this
                 return -1;
             }
         }
         else
             return (T)HttpRuntime.Cache[key];
    }
