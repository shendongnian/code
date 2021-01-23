    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        base.OnActionExecuting(filterContext);
        this.ViewBag["IsAuthenticated"] = this.Request.IsAuthenticated;
        // ...
    }
