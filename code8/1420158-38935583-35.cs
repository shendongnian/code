    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context /* other scoped dependencies */)
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
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // if it's not one of the expected exception, set it to 500
            var code = HttpStatusCode.InternalServerError;
            if (exception is MyNotFoundException) 
                code = HttpStatusCode.NotFound;
            else if (exception is MyUnauthorizedException) 
                code = HttpStatusCode.Unauthorized;
            else if (exception is MyException) 
                code = HttpStatusCode.BadRequest;
            // Send response to the client
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)code;
            return response.WriteAsync(JsonConvert.SerializeObject(new 
            {
                error = exception.Message
            }));
        }
    }
