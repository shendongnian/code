    public class CustomHeaderFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
           actionExecutedContext.Response.Content.Headers.Add("totalHeader", "Return Value");
        }
    }
