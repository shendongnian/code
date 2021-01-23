    public class CustomErrorAttribute : HandleErrorAttribute 
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;// This causes the webconfig httpErrors section to be ignored, since we are handling the exception
            filterContext.ExceptionHandled = true;
            //... log error
            filterContext.HttpContext.Response.ClearContent();// Removes partially rendered content
            // just information to be passed in the view model, this does NOT define which view is displayed next.  It tells us where the error came from.
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            // This presents an error page view.  By default if a View is not passed to the Attribute, then this is Error.cshtml in Shared.
            filterContext.Result = new ViewResult
            {
                ViewName = View,  // View & Master are parameters from the attribute e.g. [ErrorAttribute(View="OtherErrorView")], by default the view is the "Error.cshtml" view
                MasterName = Master,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };
            filterContext.Exception = null;
        }
    }
