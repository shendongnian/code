    public class MyCustomFilter : System.Web.Http.Filters.ActionFilterAttribute
    {
        public bool DisableTracing{get;set;}
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if(!DisableTracing){
                   //Do something here before an action method starts executing
            }
        }
        public override void OnActionExecuted(System.Web.Http.Filters.HttpActionExecutedContext context)
        {
            if(!DisableTracing){
                   //Do something here before an action method starts executing
            }
        }
    }
