	var provider = new CookieAuthenticationProvider();
	var originalHandler = provider.OnApplyRedirect;
	provider.OnApplyRedirect = context =>
	{
		if (!context.Request.Uri.LocalPath.StartsWith(VirtualPathUtility.ToAbsolute("~/api")))
		{
			context.RedirectUri = new Uri(context.RedirectUri).PathAndQuery;
			originalHandler.Invoke(context);
		}
	};
	app.UseCookieAuthentication(new CookieAuthenticationOptions
	{
		AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
		CookieName = FormsAuthentication.FormsCookieName,
		LoginPath = new PathString("/Account/LogOn"),
		ExpireTimeSpan = TimeSpan.FromMinutes(240),
		Provider = provider
	});
