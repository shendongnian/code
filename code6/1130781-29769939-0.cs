          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               if(roleChanged)
                {
                     context.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                      {
                         controller = "Home",
                         action = "Logout"
                      }));
                 }
          }
