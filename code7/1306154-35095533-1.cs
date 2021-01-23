        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
 
            if(!ApplicationB.Validate(username, password))
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }
            
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            // add new claims relevant for your identity (ex: PortalAlias)
            
            context.Validated(identity);
 
        }
