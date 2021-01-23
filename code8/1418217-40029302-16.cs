    namespace System.Web
    {
    
        namespace Hosting
        {
            public static class HostingEnvironment 
            {
                public static bool m_IsHosted;
    
                static HostingEnvironment()
                {
                    m_IsHosted = false;
                }
    
                public static bool IsHosted
                {
                    get
                    {
                        return m_IsHosted;
                    }
                }
            }
        }
    
    
        public static class HttpContext
        {
            public static IServiceProvider ServiceProvider;
    
            static HttpContext()
            { }
    
    
            public static Microsoft.AspNetCore.Http.HttpContext Current
            {
                get
                {
                    // var factory2 = ServiceProvider.GetService<Microsoft.AspNetCore.Http.IHttpContextAccessor>();
                    object factory = ServiceProvider.GetService(typeof(Microsoft.AspNetCore.Http.IHttpContextAccessor));
    
                    // Microsoft.AspNetCore.Http.HttpContextAccessor fac =(Microsoft.AspNetCore.Http.HttpContextAccessor)factory;
                    Microsoft.AspNetCore.Http.HttpContext context = ((Microsoft.AspNetCore.Http.HttpContextAccessor)factory).HttpContext;
                    // context.Response.WriteAsync("Test");
    
                    return context;
                }
            }
    
    
        } // End Class HttpContext 
    
    
    }
