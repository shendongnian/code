    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
        var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
        var user = await userManager.FindByNameAsync(context.UserName);
        
        if (user == null)
        { 
            context.SetError("invalid_grant", "Wrong username or password."); //user not found
            return;
        }
        if (await userManager.IsLockedOutAsync(user.Id))
        {
            context.SetError("locked_out", "User is locked out");
            return;
        }
        var check = await userManager.CheckPasswordAsync(user, context.Password);
        if (!check)
        {
            await userManager.AccessFailedAsync(user.Id);
            context.SetError("invalid_grant", "Wrong username or password."); //wrong password
            return;
        }
        await userManager.ResetAccessFailedCountAsync(user.Id);
        ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager,
           OAuthDefaults.AuthenticationType);
        ClaimsIdentity cookiesIdentity = await user.GenerateUserIdentityAsync(userManager,
            CookieAuthenticationDefaults.AuthenticationType);
        AuthenticationProperties properties = CreateProperties(user.UserName);
        AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, properties);
        context.Validated(ticket);
        context.Request.Context.Authentication.SignIn(cookiesIdentity);
    }
