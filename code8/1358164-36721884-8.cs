    public class RedirectMiddleware
    {
        private readonly RequestDelegate _next;
        public RedirectMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            // if specific condition does not meet
            if (context.Request.Path.ToString().Equals("/bar"))
            {
                context.Response.Redirect("path/to/controller/action");
            }
            else
            {
                await _next.Invoke(context);
            }
        }
    }
