    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
    {
        var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin") ?? "*";
    
        context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });
    
        var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();
                
        ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);
    
        if (user == null)
        {
            context.SetError("invalid_grant", "The user name or password is incorrect.");
            return;
        }
    
        var identity = new ClaimsIdentity(context.Options.AuthenticationType);
        identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
        identity.AddClaim(new Claim("sub", context.UserName));
    
        //this loop is where the roles are added as claims
        foreach (var role in userManager.GetRoles(user.Id))
        {
            identity.AddClaim(new Claim(ClaimTypes.Role, role));
        }
    
        var props = new AuthenticationProperties(new Dictionary<string, string>
        {
            {
                "as:client_id", context.ClientId ?? string.Empty
            },
            {
                "userName", context.UserName
            }
        });
    
        var ticket = new AuthenticationTicket(identity, props);
        context.Validated(ticket);
    }
