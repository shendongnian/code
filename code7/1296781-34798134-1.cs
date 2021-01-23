      protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
      {
      	System.Web.Routing.RouteValueDictionary rd = null;
      	if (filterContext.HttpContext.User.Identity.IsAuthenticated)
      	{
      		//Redirect to Not Authorized
      		rd = new System.Web.Routing.RouteValueDictionary(new { action = "NotAuthorized", controller = "Error", area = "" });
      	}
      	else
      	{
      		//Redirect to Login
      		rd = new System.Web.Routing.RouteValueDictionary(new { action = "Login", controller = "Account", area = "" });
      		//See if we need to include a ReturnUrl
      		if (!string.IsNullOrEmpty(filterContext.HttpContext.Request.RawUrl) && filterContext.HttpContext.Request.RawUrl != "/")
      			rd.Add("ReturnUrl", filterContext.HttpContext.Request.RawUrl);
      	}
        //Set context result
        filterContext.Result = new RedirectToRouteResult(rd);
      }
