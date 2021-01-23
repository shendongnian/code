    var options = new FacebookAuthenticationOptions
    {
        AppId = "-------",
        AppSecret = "------",    
    };
    options.Scope.Add("public_profile");
    options.Scope.Add("email");
    //add this for facebook to actually return the email and name
    options.Fields.Add("email");
    options.Fields.Add("name");
    app.UseFacebookAuthentication(options);
