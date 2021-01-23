    public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (UserManager<IdentityUser> userManager = _userManagerFactory())
            {
                IdentityUser user = await userManager.FindAsync(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    context.Response.Headers.Add(Constants.OwinChallengeFlag, new[] { ((int)HttpStatusCode.Unauthorized).ToString() }); //Little trick to get this to throw 401, refer to STTIAuthenticationMiddleware for more
                    //return;
                }
                ....
