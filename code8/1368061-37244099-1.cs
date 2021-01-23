    public class AuthMiddleware : AuthenticationMiddleware<AuthOptions>
    {
        public AuthMiddleware(OwinMiddleware next, IAppBuilder app, AuthOptions options)
            : base(next, options)
        {
            if (options.StateDataFormat == null)
            {
                options.StateDataFormat = new PropertiesDataFormat(new AesDataProtectorProvider("myAuthKey"));
            }
        }
        protected override AuthenticationHandler<AuthOptions> CreateHandler()
        {
            return new AuthHandler();
        }
    }
