    public class HttpExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is HttpException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
