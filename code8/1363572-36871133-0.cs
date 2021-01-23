    if (filterContext.HttpContext.Request.IsAjaxRequest())
     {
         filterContext.Result = new JsonResult { Data = Url.Action("Login","Login")};
     }
     else
     {
        filterContext.Result = new RedirectToRouteResult(
                                   new RouteValueDictionary
                                   {
                                       { "action", "Login" },
                                       { "controller", "Login" }
                                   });
     }
