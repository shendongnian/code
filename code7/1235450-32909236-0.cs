    public class HandleExceptionAttribute : ExceptionFilterAttribute
        {
            private HttpStatusCode _status;
            private Type _type;
    
            public Type Type
            {
                get { return _type; }
                set { _type = value; }
            }
    
            public HttpStatusCode Status
            {
                get { return _status; }
                set { _status = value; }
            }
    
            public override void OnException(HttpActionExecutedContext context)
            {
                var exception = context.Exception;
    
                if (exception == null || exception.GetType() != Type) return;
    
                var response = context.Request.CreateErrorResponse(Status, exception.Message, exception);
    
                throw new HttpResponseException(response);
            }
        }
