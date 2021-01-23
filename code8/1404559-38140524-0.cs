    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        filterContext.HttpContext.Items["timer"] = Stopwatch.StartNew();
        base.OnActionExecuting(filterContext);
    }
