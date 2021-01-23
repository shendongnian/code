    public class MyCustomFilter : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //Do something here before an action method starts executing
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Do something here after an action method finished executing
        }
    }
