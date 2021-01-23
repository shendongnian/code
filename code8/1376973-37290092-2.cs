    public class CustomFilterAttribute : ActionFilterAttribute {
        public ILog Log { get; set; }
    
        public override void OnActionExecuting(HttpActionContext actionContext) {
            var id = int.Parse(actionContext.ActionArguments["id"].ToString());
            Log = actionContext
                .RequestContext
                .Configuration
                .DependencyResolver
                .GetService(typeof(ILog))
                as ILog;
    
    
           Log.WriteMessage(string.Format("Got id:{0}",id));
       }
    }
