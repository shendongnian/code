public class StopwatchAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);
            actionContext.Request.Properties[actionContext.ActionDescriptor.ActionName] = Stopwatch.StartNew();
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            Stopwatch stopwatch = (Stopwatch)actionExecutedContext.Request.Properties[actionExecutedContext.ActionContext.ActionDescriptor.ActionName];
            if (actionExecutedContext.Response != null && actionExecutedContext.Response.Content != null)
            {
                actionExecutedContext.Response.Content.Headers.TryAddWithoutValidation("Execution-Time", stopwatch.ElapsedMilliseconds.ToString());
            }
        }
    }
  [1]: https://www.c-sharpcorner.com/UploadFile/db2972/trace-web-api-execution-time-using-custom-action-filter/
