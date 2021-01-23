    public static class HttpContextExtensions
    {
        public static CurrentAccess GetCurrentAccess(this HttpContext httpContext)
        {
            return httpContext.RequestServices.GetRequiredService<CurrentAccess>();
        }
    }
