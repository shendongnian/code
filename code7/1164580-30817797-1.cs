    public class UrlRewriteMiddleware
    {
        private readonly RequestDelegate next;
        public UrlRewriteMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            // Redirect from /some/page.htm to /some/page
            Regex r1 = new Regex("^/some/[a-zA-Z0-9]+\\.htm$");
            if (r1.IsMatch(context.Request.Path.Value))
            {
                context.Response.Redirect(context.Request.Path.Value.Substring(0, context.Request.Path.Value.Length - 4));
                return;
            }
            // Rewrite from /some/page to /some/page.htm
            Regex r2 = new Regex("^/some/[a-zA-Z0-9]+$");
            if (r2.IsMatch(context.Request.Path.Value))
                context.Request.Path = new PathString(context.Request.Path.Value + ".htm");
            await next(context);
        }
    }
