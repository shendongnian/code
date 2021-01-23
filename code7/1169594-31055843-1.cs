    public void SignIn()
    {
        IAuthenticationManager manager = HttpContext.Current.GetOwinContext().Authentication;
        var externalData = manager.GetExternalLoginInfo();
        
        UserDto user = this.userBusinessLogic.GetUser(externalData.Login.LoginProvider, externalData.Login.ProviderKey);
        if (user == null)
        {
            user = this.userBusinessLogic.AddUser(
                new UserDto
                { 
                    FirstName = externalData.ExternalIdentity.Claims.Single(c => c.Type == "FirstName").Value,
                    LastName = externalData.ExternalIdentity.Claims.Single(c => c.Type == "LastName").Value
                },
                externalData.Login.LoginProvider,
                externalData.Login.ProviderKey,
                // here's the token claim that I set in the middleware configuration
                externalData.ExternalIdentity.Claims.Single(c => c.Type == "AccessToken").Value);
        }
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
            new Claim(ClaimTypes.UserData, UserData.FromUserDto(user).ToString()),
            new Claim("AccessToken", user.Token),
            new Claim("FirstName", user.FirstName),
            new Claim("LastName", user.LastName)
        };
        var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
        var properties = new AuthenticationProperties
        {
            AllowRefresh = true,
            IsPersistent = true
        };
        manager.SignIn(properties, identity);
    }
