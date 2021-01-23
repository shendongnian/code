    public class RequestLoggerMiddleware
    {
        private readonly Func<IDictionary<string, object>, Task> _next;
        private readonly ILogger _logger;
        public RequestLoggerMiddleware(
            Func<IDictionary<string, object>, Task> next, 
            ILogger logger)
        {
            _next = next;
            _logger = logger;
        }
        public Task Invoke(IDictionary<string, object> environment)
        {
            var context = new OwinContext(environment);
            _logger.Write($"{context.Request.Method} {context.Request.Uri.AbsoluteUri}");
            var result = _next.Invoke(environment);
            _logger.Write($"Status code: {context.Response.StatusCode}");
            return result;
        }
    }
