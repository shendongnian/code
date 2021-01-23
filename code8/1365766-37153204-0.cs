    public class IsLoggedInAsHero : AuthorizeAttribute
        {
           protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
           {
                if (!isAuthenticatedAsHero())
                {
                    base.HandleUnauthorizedRequest(filterContext);
                }
           }
        }
