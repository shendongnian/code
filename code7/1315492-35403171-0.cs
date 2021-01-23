    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        ...
        public override Task AuthorizationEndpointResponse(OAuthAuthorizationEndpointResponseContext context)
        {
            var props = context.OwinContext.Authentication.AuthenticationResponseGrant.Properties.Dictionary;
            foreach (var k in props.Keys)
            {
                if (k[0] != '.' && !string.Equals(k,"client_id",StringComparison.OrdinalIgnoreCase))
                {
                    context.AdditionalResponseParameters.Add(k, props[k]);
                }
            }
            return base.AuthorizationEndpointResponse(context);
        }
