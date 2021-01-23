    OAuthOptions = new OAuthAuthorizationServerOptions
    {
        TokenEndpointPath = new PathString("/Token"),
        Provider = new ApplicationOAuthProvider(PublicClientId),
        AccessTokenProvider = new AuthenticationTokenProvider
        {
            OnCreate = (context) =>
            {
                var token = context.SerializeTicket();
                var guid = Guid.NewGuid().ToString("N");
                // You need to implement your own logical here, for example, store the mapping (guid => token) into database
                RedisServer.SetValue(guid, token, TimeSpan.FromDays(Consts.AccessTokenExpireDays)); 
                context.SetToken(guid);
            },
            OnReceive = (context) =>
            {
                var token = RedisServer.GetValue(context.Token);
                context.DeserializeTicket(token);
            }
        },
        AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
        AccessTokenExpireTimeSpan = TimeSpan.FromDays(Consts.AccessTokenExpireDays),
        // In production mode set AllowInsecureHttp = false
        AllowInsecureHttp = true,
    };
