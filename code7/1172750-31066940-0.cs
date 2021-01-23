    //needed for CreateErrorResponse(statusCode, message)
    using System.Net.Http
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            //you can get the underlying exception here
            var type = context.Exception.GetType();
            //I like to map exception types to status codes
            var statusCode = GetHttpStatusCode(type);
            //respond with a proper status code and the message
            context.Response = context.Request.CreateErrorResponse(statusCode, context.Exception.Message);
        }
    }
