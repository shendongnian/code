    public class CustomAuthAttribute : FilterAttribute, IActionFilter { 
         public void OnActionExecuting(ActionExecutingContext filterContext) {
             if (filterContext.HttpContext.Session["User"] == null)
             {
                filterContext.Result = new RedirectToRouteResult(
                                          new RouteValueDictionary 
                                          {
                                             { "action", "Login" },
                                             { "controller", "Account" }
                                          }); 
             }
         } 
    }
