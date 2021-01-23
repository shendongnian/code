    public class MyAuthorisationFilter : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {   
            var principal = HttpContext.Current.User as ClaimsPrincipal;
            
            if(!principal.Claims.Any(c => c.Type == "My Claim Name"))
            {
                // user has no claim - do redirection
                // you need to create 'AuthenticateAgain' route to your table of routes
                // or you can do other means of redirection
                filterContext.Result = new RedirectToRouteResult("AuthenticateAgain", new RouteValueDictionary());
            }
        }
    }
