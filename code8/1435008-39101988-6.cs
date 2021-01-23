    [AllowAnonymous]
    public ActionResult OpenIdAuth(string code)
    {
        string clientId = "00000000-0000-0000-0000-000000000000"; // Client ID found in the Azure AD Application
        string appKey = "111111111112222222222223333333333AAABBBCCC="; // Key generated in the Azure AD Appliction
        if (code != null)
        {
            string commonAuthority = "https://login.windows.net/<TENANT_URL>";  // Eg. https://login.windows.net/MyDevSite.onmicrosoft.com
            var authContext = new AuthenticationContext(commonAuthority);
            ClientCredential credential = new ClientCredential(clientId, appKey);
            AuthenticationResult authenticationResult = authContext.AcquireTokenByAuthorizationCode(code, new Uri(HttpContext.Request.Url.GetLeftPart(UriPartial.Path)), credential, "https://graph.windows.net");
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            var user = UserManager.FindByName(authenticationResult.UserInfo.UniqueId);
            if (user != null)
            {
                signInManager.SignIn(user, false, false);
            }
            else
            {
                var newUser = new ApplicationUser { UserName = authenticationResult.UserInfo.UniqueId, Email = authenticationResult.UserInfo.DisplayableId };
                var creationResult = UserManager.Create(newUser);
                if (creationResult.Succeeded)
                {
                    user = UserManager.FindByName(newUser.UserName);
                    signInManager.SignIn(user, false, false);
                }
                else
                {
                    return new ViewResult { ViewName = "Error" };
                }
            }
            return Redirect("/");
        }
        else
        {
            var url = new Uri($"https://login.microsoftonline.com/<TENANT_URL>/oauth2/authorize?client_id={clientId}&response_type=code&redirect_uri=https://localhost/Account/OpenIdAuth");
            return Redirect(url.AbsoluteUri);
        }
    }
