    protected override void OnActionExecuting(ActionExecutingContext context)
    {
        var session = System.Web.HttpContext.Current.Session;
        HttpSessionStateBase sessionBase = new HttpSessionStateWrapper(session);
        // ...
    }
