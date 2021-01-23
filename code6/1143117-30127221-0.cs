    public class RedirectIfNullSessionAttribute : ActionFilterAttribute
    {
      public override void OnActionExecuting(ActionExecutingContext filterContext)
      {
        if (filterContext.HttpContext.Session["FirstName"] == null) 
        {
          filterContext.Result = new RedirectToRouteResult(
            new RouteValueDictionary 
              { 
                { "controller", "Account" }, 
                { "action", "Login" } 
              });
        }
      }
    }
