    class partial Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // ...
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
              {
                ClientId = clientId,
                Authority = authority,
                Notifications = new OpenIdConnectAuthenticationNotifications() {
                    AuthorizationCodeReceived = (context) => {
                       string authorizationCode = context.Code;
                       // (tricky) the authorizationCode is available here to use, but...
                       return Task.FromResult(0);
                    }
                }
              }
        }
    }
