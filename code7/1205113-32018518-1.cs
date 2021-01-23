    public class CustomHeaderFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
           var count = actionExecutedContext.Request.Properties["Count"];
           actionExecutedContext.Response.Content.Headers.Add("totalHeader", count);
        }
    }
