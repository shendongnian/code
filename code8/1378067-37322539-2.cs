    public class ValidationExceptionMiddleware  
    {
        private readonly RequestDelegate _next;
    
        public ValidationExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task Invoke(HttpContext context)  
        {
            // Handle exceptions and propagate appropriate response
            await _next.Invoke(context);
        }
    }
