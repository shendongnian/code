    public override void OnException(ExceptionContext filterContext)
    {
        // Log to elmah using a helper method
        ErrorLog.LogError(filterContext.Exception, "Oh no!");
        var controllerName = (string)filterContext.RouteData.Values["controller"];
        var actionName = (string)filterContext.RouteData.Values["action"];
        if (!filterContext.HttpContext.IsCustomErrorEnabled)
        {
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
            filterContext.Result = new ViewResult
            {
                ViewName = "_ChildActionOnlyError",
                MasterName = Master,
                ViewData = new ViewDataDictionary(model),
                TempData = filterContext.Controller.TempData
            };
            return;
        }
    }
