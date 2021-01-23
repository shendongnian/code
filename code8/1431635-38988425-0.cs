    public class GenericMiddleware
    {
        public GenericMiddleware(RequestDelegate next)
        {
            _next = next;
        }
    
        readonly RequestDelegate _next;
    
        public async Task Invoke(HttpContext context, IHostingEnvironment hostingEnviroment)
        {
            //do something
    
            await _next.Invoke(context);
        }
    }
