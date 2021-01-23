    public void OnException(System.Web.Mvc.ExceptionContext context)
    {
        if (context.Exception is UnauthorizedAccessException)
        {
            // Redirect to login page again
            // 1
            filterContext.Result = new RedirectToRouteResult(
            new RouteValueDictionary {{ "Controller", "YourController" },
                                      { "Action", "YourAction" } });
            // 2
           Controller controller = filterContext.Controller as Controller;
           if (controller != null)
           {
               filterContext.Cancel = true;
               controller.HttpContext.Response.Redirect("./Login");
           }
            context.ExceptionHandled = true;
        }
        base.OnException(filterContext);
    }
