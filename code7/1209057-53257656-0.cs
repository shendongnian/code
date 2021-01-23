    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
       filterContext.Result = new RedirectToRouteResult(
                                new RouteValueDictionary (new {controller = "CustomError", action = "Unauthorized"}));
    }
