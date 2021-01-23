	// Step 1 : Redirect user to go on Twitter.com to authenticate
	public ActionResult TwitterAuth()
	{
		var appCreds = new ConsumerCredentials("CONSUMER_KEY", "CONSUMER_SECRET");
		// Specify the url you want the user to be redirected to
		var redirectURL = "http://" + Request.Url.Authority + "/Home/ValidateTwitterAuth";
		var authenticationContext = AuthFlow.InitAuthentication(appCreds, redirectURL);
		return new RedirectResult(authenticationContext.AuthorizationURL);
	}
	// Step 2 : On redirected url
	public ActionResult ValidateTwitterAuth()
	{
		// Get some information back from the URL
		var verifierCode = Request.Params.Get("oauth_verifier");
		var authorizationId = Request.Params.Get("authorization_id");
		// Create the user credentials
		var userCreds = AuthFlow.CreateCredentialsFromVerifierCode(verifierCode, authorizationId);
		// Do whatever you want with the user now!
		ViewBag.User = Tweetinvi.User.GetAuthenticatedUser(userCreds);
		return View();
	}
