    // Facebook integration
    var facebookOptions = new Microsoft.Owin.Security.Facebook.FacebookAuthenticationOptions()
    {
        AppId = ConfigurationManager.AppSettings["Facebook.appID"],
        AppSecret = ConfigurationManager.AppSettings["Facebook.appSecret"],
        Provider = new Microsoft.Owin.Security.Facebook.FacebookAuthenticationProvider()
        {
            OnAuthenticated = (context) =>
            { 
                // STORE THE USER ACCESS TOKEN GIVEN TO US BY FACEBOOK FOR THIS USER
                context.Identity.AddClaim(new System.Security.Claims.Claim("urn:facebook:access_token", context.AccessToken, XmlSchemaString, "Facebook"));
                foreach (var x in context.User)
                {
                    var claimType = string.Format("urn:facebook:{0}", x.Key);
                    string claimValue = x.Value.ToString();
                    if (!context.Identity.HasClaim(claimType, claimValue))
                                            context.Identity.AddClaim(new Claim(claimType, claimValue, XmlSchemaString, "Facebook"));
                        
                 }
                 return Task.FromResult(0);
            }
        }
     };
  
     facebookOptions.Scope.Add("email");
     facebookOptions.Scope.Add("publish_actions");
     app.UseFacebookAuthentication(facebookOptions);
