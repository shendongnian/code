     public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public Type ExceptionType { get; set; }
        public HandleExceptionAttribute(Type exceptionType)
        {
            ExceptionType = exceptionType;
        }
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception.GetType()==ExceptionType)
            {
                var response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.Moved);
                response.Headers.Location=new Uri("http://google.co.uk");
                response.Content=new StringContent("Message");
                actionExecutedContext.Response = response;
            }
            base.OnException(actionExecutedContext);
        }
    }
