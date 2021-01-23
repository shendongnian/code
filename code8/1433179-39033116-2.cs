    public class MyCustomFilter : ActionFilterAttribute
    {
        public bool DisableTracing{get;set;}
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            if(!DisableTracing){
                   //Do something here before an action method starts executing
            }
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if(!DisableTracing){
                   //Do something here before an action method starts executing
            }
        }
    }
