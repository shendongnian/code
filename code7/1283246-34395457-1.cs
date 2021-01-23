  	protected void Application_BeginRequest(object sender, EventArgs e)
	{
		HttpContext context = HttpContext.Current;
		if (!context.Request.IsSecureConnection && !context.Request.IsLocal)
		{
			Response.Redirect(context.Request.Url.ToString().Replace("http:", "https:"));
		}
	}
