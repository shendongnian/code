    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        var controller = filterContext.Controller as BaseController;
    
        if (controller != null)
        {
            if (controller.Session.IsNewSession)
            {
                var routeDictionary = filterContext.RouteData.DataTokens;
    
                filterContext.Result = new SessionTimeoutRedirectResult(
                    "Error500",
                    routeDictionary,
                    RedirectActionName,
                    RedirectControllerName);
            }
        }
    
        base.OnActionExecuting(filterContext);
    }
