    public void ConfigureAuth(IAppBuilder app)
    {
    	app.UseCookieAuthentication(new CookieAuthenticationOptions
    	{
    		AuthenticationType =  
    		DefaultAuthenticationTypes.ApplicationCookie,
    		LoginPath = new PathString("/Account/Login"),
    		ExpireTimeSpan = new System.TimeSpan(90, 0, 0, 0),
    		CookieHttpOnly = false,
    		SlidingExpiration = true,
    	});
       app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
    }
