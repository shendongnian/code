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
                       // the authorizationCode is available here, so you can ask for access or store it, but...
                       return Task.FromResult(0);
                    }
                }
              }
        }
    }
