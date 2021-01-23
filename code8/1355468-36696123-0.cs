    /* Some other customer stuff that isn't relevant */
    base.OnAuthorization(filterContext);
	if (System.Web.HttpContext.Current.Application[filterContext.HttpContext.User.Identity.Name] != null &&
		((bool)System.Web.HttpContext.Current.Application[filterContext.HttpContext.User.Identity.Name]) == true)
	{
		//The user is ok to log in, and should be validated now.
	}
	else
	{
		HandleUnauthorizedRequest(filterContext);
	}
