    public static class GenericMiddlewareExtensions
    {
        public static IApplicationBuilder UseGenericMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<GenericMiddleware>();
            return app;
        }
    }
