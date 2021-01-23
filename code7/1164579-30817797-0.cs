    public class CustomErrorMiddleware
    {
        private readonly RequestDelegate next;
        public CustomErrorMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            context.Response.StatusCode = 404;
            context.Response.ContentType = "text/html";
            await context.Response.SendFileAsync("/errors/404.html");
        }
    }
