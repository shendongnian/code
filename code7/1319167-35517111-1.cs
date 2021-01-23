     protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
        {
            base.HandleUnauthorizedRequest(filterContext);
    
            if (!_authorized)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "ErrorPage",
                    action = "Unauthorized"
                }));
            }
        }
