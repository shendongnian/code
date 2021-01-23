    public class MyCustomFilter : System.Web.Mvc.ActionFilterAttribute
    {
        public bool DisableTracing{get;set;}
        public override void OnActionExecuting(System.Web.Mvc.ResultExecutingContext filterContext)
        {
            if(!DisableTracing){
                   //Do something here before an action method starts executing
            }
        }
        public override void OnActionExecuted(System.Web.Mvc.ActionExecutedContext filterContext)
        {
            if(!DisableTracing){
                   //Do something here before an action method starts executing
            }
        }
    }
