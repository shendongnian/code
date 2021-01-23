    public static class ResponseExceptionHelper
    {
        public static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (exception == null) return;
            if (exception is MyNotFoundException)
                await WriteExceptionAsync(context, exception, HttpStatusCode.NotFound);
            else if (exception is MyUnauthorizedException)
                await WriteExceptionAsync(context, exception, HttpStatusCode.Unauthorized);
            else if (exception is MyException)
                await WriteExceptionAsync(context, exception, HttpStatusCode.BadRequest);
            else
                await WriteExceptionAsync(context, exception, HttpStatusCode.InternalServerError);
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
            }));
        }
    }
