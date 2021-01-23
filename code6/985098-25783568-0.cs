	public ActionResult ExternalLoginCallback()
	{
		AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback"));
		if (!result.IsSuccessful)
		{
			return RedirectToAction("ExternalLoginFailure");
		}
		if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
		{
			var db = new MyDataClassesDataContext();
			var user = db.ExecuteQuery<UserProfile>("SELECT TOP 1 up.* FROM [dbo].webpages_OAuthMembership oam JOIN [dbo].UserProfile up ON (up.UserId = oam.UserId) WHERE oam.ProviderUserId = '" + result.ProviderUserId + "'").FirstOrDefault();
			// Do your post login stuff here
			return RedirectToAction("SomewhereAfterLogin");
		}
		// Here goes creating a new account in case external wasn't in the system before
	}
