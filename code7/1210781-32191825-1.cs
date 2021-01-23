     public void ConfigureAuth(IAppBuilder app) {
        //...
       var daysStr = System.Configuration.ConfigurationManager.AppSettings["cookieExpirationDays"];
       var days = string.IsNullOrEmpty(daysStr) ? 14 : int.Parse(daysStr);
        OAuthOptions = new OAuthAuthorizationServerOptions
        { 
        //...
        AccessTokenExpireTimeSpan = TimeSpan.FromDays(days),
      };
    }
