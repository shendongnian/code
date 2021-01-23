    public class RedirectHandler
    {
        private readonly RequestDelegate _next;
        public RedirectHandler(RequestDelegate next)
        {
            _next = next;
        }
        public bool IsAjaxRequest(HttpContext context)
        {
            return context.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
        public bool IsFetchRequest(HttpContext context)
        {
            return context.Request.Headers["X-Requested-With"] == "Fetch";
        }
        public async Task Invoke(HttpContext context)
        {
            await _next.Invoke(context);
            var ajax = IsAjaxRequest(context);
            var fetch = IsFetchRequest(context);
            if (context.Response.StatusCode == 302 && (ajax || fetch))
            {
                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }
        }
    }
