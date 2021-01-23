    var facebookOptions = new FacebookAuthenticationOptions
    {
    	AppId = "*",
    	AppSecret = "*",
    };
    const string XmlSchemaString = "http://www.w3.org/2001/XMLSchema#string";
    facebookOptions.Provider = new FacebookAuthenticationProvider
    {
    	OnAuthenticated = context =>
    	{
    		void addClaim(
    			FacebookAuthenticatedContext ctx,
    			string faceBookClaim,
    			string aspNetClaim)
    		{
    			if (context.User.TryGetValue(faceBookClaim, out JToken t))
    			{
    				ctx.Identity.AddClaim(
    					new Claim(
    						aspNetClaim,
    						t.ToString(),
    						XmlSchemaString,
    						facebookOptions.AuthenticationType));
    			}
    		}
    
    		addClaim(context, "first_name", ClaimTypes.GivenName);
    		addClaim(context, "last_name", ClaimTypes.Surname);
    		return Task.CompletedTask;
    	}
    };
    
    facebookOptions.Scope.Add("public_profile");
    facebookOptions.Scope.Add("email");
    
    facebookOptions.Fields.Add("email");
    facebookOptions.Fields.Add("name");
    facebookOptions.Fields.Add("first_name");
    facebookOptions.Fields.Add("last_name");
    app.UseFacebookAuthentication(facebookOptions);
