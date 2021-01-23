    namespace System.Web
    {
        public static class HttpContext
        {
            private static IHttpContextAccessor _contextAccessor;
     
            public static Microsoft.AspNetCore.Http.HttpContext Current => _contextAccessor.HttpContext;
     
            internal static void Configure(IHttpContextAccessor contextAccessor)
            {
                _contextAccessor = contextAccessor;
            }
        }
    }
