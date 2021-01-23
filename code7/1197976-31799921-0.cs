    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
        if (IsValid())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    protected bool IsValid()
    {
        //custom authentication logic
        return true;
    }
    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext) {
        
        filterContext.Result = new RedirectToRouteResult(
                                   new RouteValueDictionary 
                                   {
                                       { "action", "ActionName" },
                                       { "controller", "ControllerName" }
                                   });
    }
