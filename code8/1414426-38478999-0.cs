    OAuthOptions = new OAuthAuthorizationServerOptions
    {
         TokenEndpointPath = new PathString("/GetAuthToken",
            Provider = new ApplicationOAuthProvider(PublicClientId, UserManagerFactory),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin",
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(10),
                AllowInsecureHttp = true,
                AccessTokenProvider = new AuthenticationTokenProvider()
                {
                    OnReceive = context =>
                    {
                        context.DeserializeTicket(context.Token);
                        // After this you can be sure that your ticket is initialized and have
                        // an access to the user
                        if(context.Ticket.Identity.IsAuthenticated)
                            EntityContext.UserId = context.Ticket.Identity.GetUserId();
                        else
                            EntityContext.UserId = "";
                    }
                }
    };
