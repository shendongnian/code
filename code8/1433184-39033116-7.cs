    public class MyCustomFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //Do something here before an action method starts executing
        }
        public override void OnActionExecuted(System.Web.Http.Filters.HttpActionExecutedContext context)
        {
            //Do something here after an action method finished executing
        }
    }
