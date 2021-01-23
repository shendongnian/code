    public class CustomExceptionFilter : ExceptionFilterAttribute
    
        {
           public override void OnException(HttpActionExecutedContext actionExecutedContext)
          {
            message = "Web API Error";
            status = HttpStatusCode.InternalServerError;
            actionExecutedContext.Response = new HttpResponseMessage()
            {
                Content = new StringContent(message, System.Text.Encoding.UTF8, "text/plain"),
                StatusCode = status
            };
            base.OnException(actionExecutedContext);
        }
    }
