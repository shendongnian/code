    public class AuthHandler : AuthenticationHandler<AuthOptions>
    {
        protected override Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            // This method never gets called in the current setup,
            // but it is required because the compilation fails otherwise.
            // Therefore only return an empty object.
            return Task.FromResult<AuthenticationTicket>(null);
        }
        protected override Task ApplyResponseChallengeAsync()
        {
            if (Response.StatusCode == 401)
            {
                var challenge = Helper.LookupChallenge(Options.AuthenticationType, Options.AuthenticationMode);
                if (challenge != null)
                {
                    var state = challenge.Properties;
                    if (string.IsNullOrEmpty(state.RedirectUri))
                    {
                        state.RedirectUri = Request.Uri.ToString();
                    }
                    var stateString = Options.StateDataFormat.Protect(state);
                    Response.Redirect(WebUtilities.AddQueryString(Options.CallbackPath.Value, "state", stateString));
                }
            }
            return Task.FromResult<object>(null);
        }
        public override async Task<bool> InvokeAsync()
        {
            // If user is not logged in and tries to access any page that is not in
            // the list of allowed pages, redirect to login page.
            // Add any additional pages not protected by authentication here
            if (Context.Authentication.User == null && 
                !Request.Path.ToString().StartsWith("/login"))
            {
                Response.Redirect(Options.CallbackPath.Value);
                return true;
            }
            return false;
        }
    }
