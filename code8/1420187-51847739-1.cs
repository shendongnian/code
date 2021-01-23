    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IActionResultExecutor<ObjectResult> executor;
        private readonly ILogger logger;
        private readonly Func<object, Task> clearCacheHeadersDelegate;
        private static readonly ActionDescriptor EmptyActionDescriptor = new ActionDescriptor();
    
        public ExceptionHandlerMiddleware(RequestDelegate next, IActionResultExecutor<ObjectResult> executor, ILoggerFactory loggerFactory)
        {
            this.next = next;
            this.executor = executor;
            logger = loggerFactory.CreateLogger<ExceptionHandlerMiddleware>();
            clearCacheHeadersDelegate = ClearCacheHeaders;
        }
    
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An unhandled exception has occurred while executing the request. Url: {context.Request.GetDisplayUrl()}. Request Data: " + GetRequestData(context));
    
                if (context.Response.HasStarted)
                {
                    throw;
                }
    
                var routeData = context.GetRouteData() ?? new RouteData();
    
                var actionContext = new ActionContext(context, routeData, EmptyActionDescriptor);
    
                var result = new ObjectResult(new ErrorResponse("Error processing request. Server error."))
                {
                    StatusCode = (int) HttpStatusCode.InternalServerError,
                };
    
                await executor.ExecuteAsync(actionContext, result);
            }
        }
    
        private static string GetRequestData(HttpContext context)
        {
            var sb = new StringBuilder();
          
            if (context.Request.HasFormContentType && context.Request.Form.Any())
            {
                sb.Append("Form variables:");
                foreach (var x in context.Request.Form)
                {
                    sb.AppendFormat("Key={0}, Value={1}<br/>", x.Key, x.Value);
                }
            }
    
            sb.AppendLine("Method: " + context.Request.Method);
    
            return sb.ToString();
        }
    
        private static Task ClearCacheHeaders(object state)
        {
            var response = (HttpResponse)state;
            response.Headers[HeaderNames.CacheControl] = "no-cache";
            response.Headers[HeaderNames.Pragma] = "no-cache";
            response.Headers[HeaderNames.Expires] = "-1";
            response.Headers.Remove(HeaderNames.ETag);
            return Task.CompletedTask;
        }
    
        [DataContract(Name= "ErrorResponse")]
        public class ErrorResponse
        {
            [DataMember(Name = "Message")]
            public string Message { get; set; }
    
            public ErrorResponse(string message)
            {
                Message = message;
            }
        }
    }
