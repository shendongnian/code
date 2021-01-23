     public class AuthorizeActionFilterAttribute : ActionFilterAttribute
        {
          public override void OnActionExecuting(FilterExecutingContext filterContext)
          {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            Controller controller = filterContext.Controller as Controller;
    
            if (controller != null)
            {
              if (session != null && session ["authstatus"] == null)
              {
    filterContext.Result =
           new RedirectToRouteResult(
               new RouteValueDictionary{{ "controller", "Login" },
                                              { "action", "Index" }
    
                                             });
              }
            }
    
            base.OnActionExecuting(filterContext);
          }
        }
