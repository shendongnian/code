        protected async override System.Threading.Tasks.Task<AuthenticationTicket>
                    AuthenticateCoreAsync()
        {
            AuthenticationProperties properties = UnpackStateParameter(Request.Query);
            if (properties != null)
            {
                var logonUserIdentity = Options.Provider.GetLogonUserIdentity(Context);
                if (logonUserIdentity.AuthenticationType != Options.CookieOptions.AuthenticationType
                    && logonUserIdentity.IsAuthenticated)
                {
                    AddCookieBackIfExists();
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(
                        logonUserIdentity.Claims, Options.SignInAsAuthenticationType);
                    //  ExternalLoginInfo GetExternalLoginInfo(AuthenticateResult result)
                    claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier,
                      logonUserIdentity.User.Value, null, Options.AuthenticationType));
                    //could grab email from AD and add it to the claims list.
                    var ticket = new AuthenticationTicket(claimsIdentity, properties);
                    var context = new MixedAuthAuthenticatedContext(
                       Context,
                       claimsIdentity,
                       properties,
                       Options.AccessTokenFormat.Protect(ticket));
                    await Options.Provider.Authenticated(context);
                    return ticket;
                }
            }
            return new AuthenticationTicket(null, properties);
        }
