    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
        ... code obmitted
        ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);
        if (user == null)
        {
            user = await userManager.FindByNameAsync(context.UserName);
            ... null checks obmitted
            string token = context.Password;
            bool result = await userManager.VerifyUserTokenAsync(user.Id, "GRANT-ACCESS", token);
        }
        ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");
        var ticket = new AuthenticationTicket(oAuthIdentity, null);
        context.Validated(ticket);
    }
