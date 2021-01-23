    public class PasswordAuthenticationMiddleware : AuthenticationMiddleware<PasswordAuthenticationOptions>
    {
        public delegate Task<IEnumerable<Claim>> CredentialValidationFunction(string id, string secret);
        public PasswordAuthenticationMiddleware(OwinMiddleware next, PasswordAuthenticationOptions options)
            : base(next, options)
        {}
        protected override AuthenticationHandler<PasswordAuthenticationOptions> CreateHandler()
        {
            return new PasswordAuthenticationHandler(Options);
        }
    }
