      public class MvcApplication : System.Web.HttpApplication
        {
            //Internal reference to the cache wrapper object
            private static ICacheService _internalCacheObject;
    
            //Public mehtod used to inject a new caching service into the application.
            // This method is required to ensure full testability. 
            public void RegisterCacheService(ICacheService cacheService)
            {
                _internalCacheObject = cacheService;
            }
    
            //Use this property to access the underlying cache object from within
            // controller methods. Use this instead of native Cache object.
            public static ICacheService CacheService
            {
                get { return _internalCacheObject; }
            }
            protected void Application_Start()
            { 
                //Inject a global caching service
                RegisterCacheService(new AspNetCacheService());
                //Store some sample app-wide data
                CacheService["StartTime"] = DateTime.Now; 
                //Call the cache service 
                // var data = MyNameSpace.MvcApplication.CacheService[...];
            }
    
        }
