    public class ValidationExceptionMiddleware  
    {
        private readonly RequestDelegate _next;
    
        public ValidationExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        public async Task Invoke(HttpContext context)  
        {
            await _next.Invoke(context);
        }
    }
