    var authOptions = new Thinktecture.IdentityServer.Core.Configuration.AuthenticationOptions
    {
        IdentityProviders = ConfigureIdentityProviders,
        EnableLocalLogin = true,
        EnablePostSignOutAutoRedirect = true,
        LoginPageLinks = new LoginPageLink[] { 
            new LoginPageLink{
                Text = "Register",
                Href = "Register"
            }
        }
    };
