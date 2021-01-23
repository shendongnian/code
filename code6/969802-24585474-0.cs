    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      if (filterContext != null)
      {
        if (Session["UserType"] != null && Convert.ToString(Session["UserType"]) == "3") // New User
        {
          filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "ChangePassword", controller = "Login" }));
        }
      }
    }
