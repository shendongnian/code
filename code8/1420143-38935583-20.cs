    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null) return;
            // if it's not one of the expected exception, set it to 500
            var code = HttpStatusCode.InternalServerError;
            if (exception is MyNotFoundException) code = HttpStatusCode.NotFound;
            else if (exception is MyUnauthorizedException) code = HttpStatusCode.Unauthorized;
            else if (exception is MyException) code = HttpStatusCode.BadRequest;
            await WriteExceptionAsync(context, exception, code).ConfigureAwait(false);
        }
        private static async Task WriteExceptionAsync(HttpContext context, Exception exception, HttpStatusCode code)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)code;
            await response.WriteAsync(JsonConvert.SerializeObject(new 
            {
                error = new
                {
                    message = exception.Message,
                    exception = exception.GetType().Name
                }
            })).ConfigureAwait(false);
        }
    }
