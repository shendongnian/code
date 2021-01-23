    public class ResolveImageMiddleware
    {
        private readonly RequestDelegate _next;
        public ResolveImageMiddleware(RequestDelegate deg)
        {
            _next = deg;
        }
        public async Task InvokeAsync(HttpContext context, AppDbContext db)
        {
            var path = context.Request.Path;
            if (path.HasValue && path.Value.StartsWith("/imgs"))
            {
                context.Request.Path = "/Home/GetImageFromDb";
                context.Request.QueryString = new QueryString("?title=" + path.Value.Replace("/imgs/", ""));
            }
            await _next(context);
        }
    }
