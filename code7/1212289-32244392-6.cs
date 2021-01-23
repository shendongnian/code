        public class FaultExceptionFilterAttribute : ExceptionFilterAttribute 
        {
            public override void OnException(HttpActionExecutedContext context)
            {
                if (context.Exception is FaultException)
                {
                    context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
                }
            }
        }
