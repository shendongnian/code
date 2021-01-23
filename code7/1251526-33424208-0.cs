    public class LogActionFilter : ActionFilterAttribute 
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Log(actionExecutedContext.ActionContext.RequestContext.RouteData);
            base.OnActionExecuted(actionExecutedContext);
        }
        private void Log(System.Web.Http.Routing.IHttpRouteData httpRouteData)
        {
            var controllerName = "controller name";
            var actionName = "action name";
            var message = String.Format("controller:{0}, action:{1}", controllerName, actionName);
        Debug.WriteLine(message, "Action Filter Log");
        }
    }
