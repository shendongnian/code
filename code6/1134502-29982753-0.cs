    // Facebook
    app.UseFacebookAuthentication(new FacebookAuthenticationOptions
    {
    	AppId = "---",
    	AppSecret = "---",
    	Scope = { "email" }
    });
    
    // Microsoft
    app.UseMicrosoftAccountAuthentication(new MicrosoftAccountAuthenticationOptions()
    {
    	ClientId = "---",
    	ClientSecret = "---",
    	Scope = { "wl.basic", "wl.emails" }
    });
