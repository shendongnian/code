    public override Task AuthorizationEndpointResponse(OAuthAuthorizationEndpointResponseContext context)
    {
                var refreshToken = context.OwinContext.Authentication.AuthenticationResponseGrant.Properties.Dictionary["refresh_token"];
            if (!string.IsNullOrEmpty(refreshToken))
            {
                context.AdditionalResponseParameters.Add("refresh_token", refreshToken);
            }
            return base.AuthorizationEndpointResponse(context);
    }
