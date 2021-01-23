	var facebook = new FacebookAuthenticationOptions
	{
		Provider = Brass9.OwinVisitor.Auth.Facebook.
			FirstLastNameFacebookAuthenticationProvider.SplitFirstLastName(),
	#if DEBUG
		AppId = //
		AppSecret = //
	#else
		AppId = //
		AppSecret = //
	#endif
	};
	//id,name,email,first_name,last_name
	var fbScope = facebook.Scope;
	fbScope.Add("email");
	//fbScope.Add("first_name");	// Uncommenting this line will break auth
	facebook.Fields.Add("id");
	facebook.Fields.Add("email");
	facebook.Fields.Add("name");
	facebook.Fields.Add("first_name");
	facebook.Fields.Add("last_name");
	app.UseFacebookAuthentication(facebook);
