    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            var service = context.RequestServices.GetService<IMyService>();
            service.SetCompany("My Company");
            await _next.Invoke(context);
        }
    }
