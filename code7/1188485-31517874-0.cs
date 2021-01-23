    public class FooMiddleware
    {
        private readonly RequestDelegate _next;
        public FooMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context, IFarticusRepository repository)
        {
            // this will run per each request
            // do your stuff and call next middleware inside the chain.
            return _next.Invoke(context);
        }
    }
