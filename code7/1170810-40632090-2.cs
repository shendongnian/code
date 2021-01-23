	// Configure Azure AD as a provider
	var azureAdOptions = new OpenIdConnectAuthenticationOptions
	{
		AuthenticationType = Constants.Azure.AuthenticationType,
		Caption = Resources.AzureSignInCaption,
		Scope = Constants.Azure.Scopes,
		ClientId = Config.Azure.ClientId,
		Authority = Constants.Azure.AuthenticationRootUri,
		PostLogoutRedirectUri = Config.Identity.RedirectUri,
		RedirectUri = Config.Azure.PostSignInRedirectUri,
		AuthenticationMode = AuthenticationMode.Passive,
		TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = false
		},
		Notifications = new OpenIdConnectAuthenticationNotifications
		{
			AuthorizationCodeReceived = context =>
			{
                // Log all the claims returned by Azure AD
				var claims = context.AuthenticationTicket.Identity.Claims;
				foreach (var claim in claims)
				{
					Log.Debug("{0} = {1}", claim.Type, claim.Value);
				}
				return null;
			}
		},
		SignInAsAuthenticationType = signInAsType // this MUST come after TokenValidationParameters
	};
	app.UseOpenIdConnectAuthentication(azureAdOptions);
