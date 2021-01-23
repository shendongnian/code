                    var now = DateTime.UtcNow.Ticks;
                    if (now <= tokenExpiry && !string.IsNullOrWhiteSpace(accessToken)) return accessToken;
                    var clientCredential = new ClientCredential(ClientId, ClientSecret);
                    var authContext = new AuthenticationContext(string.Format("{0}/{1}", AzureActiveDirectorySignInEndpoint,
                                azureADTenantId));
                    AuthenticationResult authResult = null;
                    if (!string.IsNullOrWhiteSpace(refreshToken))
                    {
                        authResult = await authContext.AcquireTokenByRefreshTokenAsync(refreshToken, clientCredential, ADEndpoint);
                    }
                    else
                    {
    authResult = await authContext.AcquireTokenSilentAsync(Endpoint, clientCredential, new UserIdentifier(userId, UserIdentifierType.UniqueId));                        
                    }
    
                    return authResult.AccessToken;//Also you may want to cache the token again
