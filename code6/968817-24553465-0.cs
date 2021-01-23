         public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
        {
            private static ConcurrentDictionary<string, AuthenticationTicket> _refreshTokens =
                new ConcurrentDictionary<string, AuthenticationTicket>();
    
            public async Task CreateAsync(AuthenticationTokenCreateContext context)
            {.......}
            public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
            {.......}
        }
