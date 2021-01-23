    public class MyCustomErrorAttribute : HandleErrorAttribute
    {
           public override void OnException(ExceptionContext filterContext)
            {
                var controllerName = filterContext.RouteData.Values["controller"];
                var actionName = filterContext.RouteData.Values["action"];
                //Do something with the Controller or Action, e.g. Logging the exception
                base.OnException(filterContext);
            }
        }
