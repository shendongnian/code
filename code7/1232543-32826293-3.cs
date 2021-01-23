    if (identity == null || !identity.IsAuthenticated) return null;
    AuthenticationResult authResult = null;
  
    var context = identity.BootstrapContext as BootstrapContext;
    var credential = new ClientCredential(AuthConfig.ClientId, AuthConfig.AppKey);
    if (context != null && context.Token != null)
    {
        authResult = authInfo.AuthContext.AcquireToken(resourceId, authInfo.Credential,
            new UserAssertion(context.Token));
    }
    return authResult;
            
