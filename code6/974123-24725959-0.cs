    protected void Application_AuthenticateRequest(object sender, EventArgs e)
	{
		if (HttpContext.Current.User != null)
		{
			if (HttpContext.Current.User.Identity.IsAuthenticated)
			{
				//take HttpContext.Current.User.Identity.Name here
				//and rebuild values in Session if session is empty
			}
		}
	}
