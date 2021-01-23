    namespace WebAndAPILayer.Filters
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
        {
            private static SimpleMembershipInitializer _initializer;
            private static object _initializerLock = new object();
            private static bool _isInitialized;
    
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                // Ensure ASP.NET Simple Membership is initialized only once per app start
                LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
            }
    
            private class SimpleMembershipInitializer
            {
                public SimpleMembershipInitializer()
                {
                    try
                    {
                        WebSecurity.InitializeDatabaseConnection("ConnStringForWebSecurity", "UserProfile", "Id", "UserName", autoCreateTables: true);
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException("Something is wrong", ex);
                    }
                }
            }
        }
    }
