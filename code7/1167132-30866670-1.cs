    void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Trace.Write("(Custom Action Filter)Action Executing: " + filterContext.ActionDescriptor.ActionName);
    
            if (filterContext.ActionParameters["indexId"] == null)
            {
            filterContext.Result = new ViewResult
            {
                ViewName = "MyErrorView",
                ViewData = filterContext.Controller.ViewData,
                TempData = filterContext.Controller.TempData
            }
            }
            base.OnActionExecuting(filterContext);
        } 
