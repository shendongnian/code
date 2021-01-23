    public class ResponseTimeMiddleware
        {
            private const string RESPONSE_HEADER_RESPONSE_TIME = "X-Response-Time-ms";
            
            private readonly RequestDelegate _next;
    
            public ResponseTimeMiddleware(RequestDelegate next)
            {
                _next = next;
            }
    
            public Task InvokeAsync(HttpContext context)
            {
                var watch = new Stopwatch();
                watch.Start();
    
                context.Response.OnStarting(() => 
                {
                    watch.Stop();
                    var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
                    context.Response.Headers[RESPONSE_HEADER_RESPONSE_TIME] =  responseTimeForCompleteRequest.ToString(); 
                    return Task.CompletedTask;
                });
    
                // Call the next delegate/middleware in the pipeline
                return this._next(context);
            }
        }
