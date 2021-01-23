	class MyCustomFilter : FilterAttribute, IAuthorizationFilter
	{
		public void OnAuthorization(AuthorizationContext filterContext)
		{
			if (filterContext.HttpContext.Session["UserID"] == null)
			{
				filterContext.Result = new RedirectResult("/");
			}
		}
	}
