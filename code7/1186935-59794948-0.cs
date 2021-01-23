    services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
        {
            private readonly IUserService _userService;
    
            public BasicAuthenticationHandler(
                IOptionsMonitor<AuthenticationSchemeOptions> options,
                ILoggerFactory logger,
                UrlEncoder encoder,
                ISystemClock clock,
                IUserService userService)
                : base(options, logger, encoder, clock)
            {
                _userService = userService;
            }
    
            protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
            {
                if (!Request.Headers.ContainsKey("Authorization"))
                    return AuthenticateResult.Fail("Missing Authorization Header");
    
                User user = null;
                try
                {
                    var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                    var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                    var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                    var username = credentials[0];
                    var password = credentials[1];
                    user = await _userService.Authenticate(username, password);
                }
                catch
                {
                    return AuthenticateResult.Fail("Invalid Authorization Header");
                }
    
                if (user == null)
                    return AuthenticateResult.Fail("Invalid User-name or Password");
    
                var claims = new[] {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);
    
                return AuthenticateResult.Success(ticket);
            }
        }
