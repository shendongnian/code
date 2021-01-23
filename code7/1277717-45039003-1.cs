	namespace Brass9.OwinVisitor.Auth.Facebook
	{
		public static class FirstLastNameFacebookAuthenticationProvider
		{
			public static FacebookAuthenticationProvider SplitFirstLastName()
			{
				return new FacebookAuthenticationProvider
				{
	OnAuthenticated = async context =>
	{
		context.Identity.AddClaim(new System.Security.Claims.Claim(
			"FacebookAccessToken", context.AccessToken));
		foreach (var claim in context.User)
		{
			var claimType = string.Format("urn:facebook:{0}", claim.Key);
			string claimValue = claim.Value.ToString();
			if (!context.Identity.HasClaim(claimType, claimValue))
				context.Identity.AddClaim(new System.Security.Claims.Claim(
					claimType, claimValue, "XmlSchemaString", "Facebook"));
		}
	}
				};
			}
		}
	}
