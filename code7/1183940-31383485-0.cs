    public class StaffOnlyAttribute : AuthorizeAttribute
    {
      protected override bool AuthorizeCore(HttpContextBase httpContext)
      {
          return StaffId != 0;
      }
      protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
      {
          base.HandleUnauthorizedRequest(filterContext);
          filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "YourController", action = "Error" }));
      }
    }
 
