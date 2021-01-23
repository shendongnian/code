    public class TokenOptions : AuthenticationOptions
        {
            public TokenOptions() : base()
            {
                AuthenticationScheme = "Bearer";
                AutomaticAuthenticate = true;
            }
        }
    public class AuthMiddleware : AuthenticationMiddleware<TokenOptions>
    {
        protected override AuthenticationHandler<TokenOptions> CreateHandler()
        {
           return new AuthHandler(new TokenService());
        }
        public AuthMiddleware(RequestDelegate next, IOptions<TokenOptions> options, ILoggerFactory loggerFactory, UrlEncoder encoder) : base(next, options, loggerFactory, encoder)
        {
        }
    }
    public class AuthHandler : AuthenticationHandler<TokenOptions>
    {
        private ITokenService _tokenService;
        public AuthHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string token = null;
            AuthenticateResult result = null;
            string token = Helper.GetTokenFromHEader(Request.Headers["Authorization"]);
            // If no token found, no further work possible
            if (string.IsNullOrEmpty(token))
            {
                result = AuthenticateResult.Skip();
            }
            else
            {
                bool isValid = await _tokenService.IsValidAsync(token);
                if (isValid)
                {
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity("Custom");
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Name, "admin"));
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, "admin"));
                    claims.Add(new Claim(ClaimTypes.Role, "admin"));
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                    result =
                        AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal,
                            new AuthenticationProperties(), Options.AuthenticationScheme));
                }
                else
                {
                    result = AuthenticateResult.Skip();
                }
            }
            return result;
        }
    }`
 
