    public class MyExceptionFilterAttribute : ExceptionFilterAttribute 
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is Exception)
            {
                context.Response = new HttpResponseMessage { Content = new StringContent("Exception occured", System.Text.Encoding.UTF8, "text/plain"), StatusCode = HttpStatusCode.InternalServerError};
            }
        }
    }
