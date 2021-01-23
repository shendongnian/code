    public class HandleErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            // (log context.Exception here)
                        
            context.Response = context.Request.CreateResponse(HttpStatusCode.InternalServerError, new ResponseModel<object>
            {
                Success = false,
                ResultMessage = "An exception occurred while processing the request: " + context.Exception.Message
            });
        }
    }
