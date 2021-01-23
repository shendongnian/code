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
                // do your magic here to grab the cookie, extract the JWT and add it to the Authorization header
                if (context.Request.Cookies.Any(e => e.Key == authenticationCookieName))
                {
                    var cookie = context.Request.Cookies.FirstOrDefault(e => e.Key == authenticationCookieName);
                    if (cookie.Value != null)
                    {
                        var cookieValue = cookie.Value;
                        if (!string.IsNullOrEmpty(cookieValue))
                        {
                            var cookieParsed = // do your thing with cookieValue
                            context.Request.Headers.Append("Authorization", "Bearer " + cookieParsed.token);
                        }
                    }
                }
                
                await _next.Invoke(context);
            }
        }
    }
