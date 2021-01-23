    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if(filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                if (httpContext.Session["HamdunSoft"] != "HamdunSoft")
                {
                    filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new{ controller = "YourCustomController", action = "YourCustomAction" }));
                }
                else
                {
                    base.HandleUnauthorizedRequest(filterContext);
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                RouteValueDictionary(new{ controller = "Error", action = "AccessDenied" }));
            }
        }
