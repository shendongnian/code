    app.UseWsFederationAuthentication(new WsFederationAuthenticationOptions()
    {
        MetadataAddress = MetadataAddress,
        Wtrealm = Wtrealm,
        Wreply = CallbackPath,
        Notifications = new WsFederationAuthenticationNotifications()
        {
            SecurityTokenValidated = (ctx) =>
            {
               ClaimsIdentity identity = ctx.AuthenticationTicket.Identity;
               DoSomethingWithLoggedInUser(identity);
            }
         }
    };
