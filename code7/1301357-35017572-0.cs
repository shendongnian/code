    ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);
    
    if (user == null)
    {
        context.SetError("invalid_grant", "The user name or password is incorrect.");
        return;
    }
    
    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
    identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
