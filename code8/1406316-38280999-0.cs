        public class NotImplExceptionFilterAttribute : ExceptionFilterAttribute 
        {
            public override void OnException(HttpActionExecutedContext context)
            {
                 if (context.Exception is ModelException)
                 {
                    ModelException exception = (ModelException)context.Exception;
                    HttpError error = new HttpError();
                    error.Add("Message", "An error has occurred.");
                    error.Add("ExceptionMessage", exception.Message);
                    error.Add("ExceptionCode", exception.ExceptionCode);
                    error.Add("ExceptionType", exception.Source);
                    error.Add("StackTrace", exception.StackTrace);
                    context.Response = context.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, error);
                 }
            }
        }
     
