    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
       var actionMethodName = filterContext.ActionDescriptor.ActionName;
       // This will be same as your view name if you are not explicitly
       // specifying a different view name in the `return View()` call
    
    }
