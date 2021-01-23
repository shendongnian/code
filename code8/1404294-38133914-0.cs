    public class UnhandledExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            string message = "My custom message";
            context.Response = context.Request.CreateResponse(
                HttpStatusCode.InternalServerError,
                new {
                    code = 500,
                    message = message
                });
        }
    }
