    public class RootExceptionFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is Exception)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                // or...
                // context.Response.Content = new StringContent("...");
                // context.Response.ReasonPhrase = "random";
            }
        }
    }
