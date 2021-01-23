    internal class KestrelAuthHandler : IAuthenticationHandler
    {
        internal KestrelAuthHandler(HttpContext httpContext, ClaimsPrincipal user)
        {
            HttpContext = httpContext;
            User = user;
        }
        internal HttpContext HttpContext { get; }
        internal ClaimsPrincipal User { get; }
        internal IAuthenticationHandler PriorHandler { get; set; }
        public Task AuthenticateAsync(AuthenticateContext context)
        {
            if (User != null)
            {
                context.Authenticated(User, properties: null, description: null);
            }
            else
            {
                context.NotAuthenticated();
            }
            if (PriorHandler != null)
            {
                return PriorHandler.AuthenticateAsync(context);
            }
            return Task.FromResult(0);
        }
        public Task ChallengeAsync(ChallengeContext context)
        {
            bool handled = false;
            switch (context.Behavior)
            {
                case ChallengeBehavior.Automatic:
                    // If there is a principal already, invoke the forbidden code path
                    if (User == null)
                    {
                        goto case ChallengeBehavior.Unauthorized;
                    }
                    else
                    {
                        goto case ChallengeBehavior.Forbidden;
                    }
                case ChallengeBehavior.Unauthorized:
                    HttpContext.Response.StatusCode = 401;
                    // We would normally set the www-authenticate header here, but IIS does that for us.
                    break;
                case ChallengeBehavior.Forbidden:
                    HttpContext.Response.StatusCode = 403;
                    handled = true; // No other handlers need to consider this challenge.
                    break;
            }
            context.Accept();
            if (!handled && PriorHandler != null)
            {
                return PriorHandler.ChallengeAsync(context);
            }
            return Task.FromResult(0);
        }
        public void GetDescriptions(DescribeSchemesContext context)
        {
            if (PriorHandler != null)
            {
                PriorHandler.GetDescriptions(context);
            }
        }
        public Task SignInAsync(SignInContext context)
        {
            // Not supported, fall through
            if (PriorHandler != null)
            {
                return PriorHandler.SignInAsync(context);
            }
            return Task.FromResult(0);
        }
        public Task SignOutAsync(SignOutContext context)
        {
            // Not supported, fall through
            if (PriorHandler != null)
            {
                return PriorHandler.SignOutAsync(context);
            }
            return Task.FromResult(0);
        }
    }
