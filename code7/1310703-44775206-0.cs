    using Microsoft.AspNetCore.Http;
    using System.Net;
    
    namespace ApiHelpers.Filters
    {
        public static class HttpContextFilters
        {
            public static bool IsLocalRequest(HttpContext context)
            {
                if (context.Connection.RemoteIpAddress.Equals(context.Connection.LocalIpAddress))
                {
                    return true;
                }
                if (IPAddress.IsLoopback(context.Connection.RemoteIpAddress))
                {
                    return true;
                }
                return false;
            }
        }
    }
