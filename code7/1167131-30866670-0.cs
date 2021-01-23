    void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Trace.Write("(Custom Action Filter)Action Executing: " + filterContext.ActionDescriptor.ActionName);
    
            if (filterContext.ActionParameters["indexId"] == null)
            {
                filterContext.Result = View("MyErrorView");
            }
            base.OnActionExecuting(filterContext);
        } 
