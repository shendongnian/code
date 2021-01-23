    protected override void OnException(ExceptionContext filterContext)
    {
        if (filterContext.Exception is MyException)
        {
            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];
            var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);
    
            filterContext.Result = new ViewResult
            {
                ViewName = actionName,
                ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                TempData = filterContext.Controller.TempData
            };    
    
            filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
        base.OnException(filterContext);
    }
