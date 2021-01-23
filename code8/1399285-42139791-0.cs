    public class AuthenticationEvents : OpenIdConnectEvents
    {
        public override Task RemoteFailure(FailureContext context)
        {
            context.HandleResponse();
            context.Response.Redirect("/Home/Error");
            return Task.FromResult(0);
        }
    }
