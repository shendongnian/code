    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
    
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public Task Invoke(HttpContext context, ApiKeyAccessor apiKeyAccessor)
        {
            StringValues key;
            if (context.Request.Headers.TryGetValue("X-Api-Key", out key))
            {
                apiKeyAccessor.ApiKey = key;
                return _next(context);
            }
                
            // todo: throw exception, etc..
        }
    }
