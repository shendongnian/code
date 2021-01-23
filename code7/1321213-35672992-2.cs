    public sealed class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            //TODO: we can handle all types of exceptions here. Out of memory, divide by zero, etc etc.
            if (context.Exception is InvalidOperationException)
            {
                var httpResponseMessage = context.Request.CreateResponse(HttpStatusCode.Redirect);
                httpResponseMessage.Headers.Location = new Uri("http://www.YourRedirectUrl");
                throw new HttpResponseException(httpResponseMessage);
            }
            if (context.Exception is UnauthorizedAccessException)
            {
                context.Response = context.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, context.Exception.Message);
                return;
            }
            if (context.Exception is TimeoutException)
            {
                throw new HttpResponseException(context.Request.CreateResponse(HttpStatusCode.RequestTimeout, context.Exception.Message));
            }
            context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Unable to process your request.");
        }
    }
