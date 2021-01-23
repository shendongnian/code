    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    
    namespace MiddlewareSample
    {
        public class JWTInHeaderMiddleware
        {
            private readonly RequestDelegate _next;
    
            public JWTInHeaderMiddleware(RequestDelegate next)
            {
                _next = next;
            }
    
            public async Task Invoke(HttpContext context)
            {
               var authenticationCookieName = "access_token";
               var cookie = context.Request.Cookies[authenticationCookieName];
               if (cookie != null)
               {
                   var token = JsonConvert.DeserializeObject<AccessToken>(cookie);
                   context.Request.Headers.Append("Authorization", "Bearer " + token.access_token);
               }
               await _next.Invoke(context);
            }
        }
    }
