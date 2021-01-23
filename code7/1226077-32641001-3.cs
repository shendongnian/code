    public class ApiExceptionAttribute : ExceptionFilterAttribute 
    {
        string _message = null;
        public ApiExceptionAttribute(string exceptionMessage = null) //to add custom message
        {
            _message = exceptionMessage;
        }
        public override void OnException(HttpActionExecutedContext context)
        {
            var message = new { 
                ExceptionType = "Custom", //or some other detail
                Message = _message == null ? "Something went wrong, please try later" : _message 
            };
            context.Response = context.Request.CreateResponse(HttpStatusCode.SeeOther, message, "application/json");
        }
    }
