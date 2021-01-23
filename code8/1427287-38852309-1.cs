    public class Logger : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            string controllerName = 
                actionContext.ControllerContext.ControllerDescriptor.ControllerName;
        }
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
        }
    }
