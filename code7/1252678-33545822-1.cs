        public async Task<JObject> GenerateLocalAccessToken(ApplicationUser user)
                {
                    ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
                            OAuthDefaults.AuthenticationType);
                  
        
                    AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
        
                    //Create the ticket then the access token
                    var ticket = new AuthenticationTicket(oAuthIdentity, properties);
    
                    ticket.Properties.IssuedUtc = DateTime.UtcNow;
                    ticket.Properties.ExpiresUtc = DateTime.UtcNow.Add(Startup.OAuthServerOptions.AccessTokenExpireTimeSpan);
    
                    var accessToken = Startup.OAuthOptions.AccessTokenFormat.Protect(ticket);
        
        
                    //Create refresh token
                    Microsoft.Owin.Security.Infrastructure.AuthenticationTokenCreateContext context =
                        new Microsoft.Owin.Security.Infrastructure.AuthenticationTokenCreateContext(
                            Request.GetOwinContext(),
                            Startup.OAuthOptions.AccessTokenFormat, ticket);
        
                    await Startup.OAuthOptions.RefreshTokenProvider.CreateAsync(context);
                    properties.Dictionary.Add("refresh_token", context.Token);
        
        
        
                    //create the Token Response
                    JObject tokenResponse = new JObject(
                                                new JProperty("access_token", accessToken),
                                                new JProperty("token_type", "bearer"),
                                                new JProperty("expires_in", Startup.OAuthServerOptions.AccessTokenExpireTimeSpan.TotalSeconds.ToString()),
                                                new JProperty("refresh_token", context.Token),
                                                new JProperty("userName", user.UserName),
                                                new JProperty(".issued", ticket.Properties.IssuedUtc.ToString()),
                                                new JProperty(".expires", ticket.Properties.ExpiresUtc.ToString())
                );
                    return tokenResponse;
        
                }
