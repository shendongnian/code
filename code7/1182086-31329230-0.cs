    public abstract class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            //Intercept results where person is authetnicated but still doesn't have permissions
            if (filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Controller.TempData["ErrorMessage"] = "Sorry, you are logged in but you have attempted to access a page that you don't have permissions to.";
                
                //TODO need to set up a route that points to your custom page, call that route RestrictedAccess
                filterContext.Result = new RedirectToRouteResult("RestrictedAccess", new RouteValueDictionary());
            }
            else
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
        }
    }
