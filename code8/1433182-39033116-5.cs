    public class MyCustomFilter : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(System.Web.Mvc.ResultExecutingContext filterContext)
        {
            //Do something here before an action method starts executing
        }
        public override void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
        {
            //Do something here after an action method finished executing
        }
    }
