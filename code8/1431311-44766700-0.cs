    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authHeader = (string)this.Request.Headers["Authorization"];
                        
            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("basic", StringComparison.OrdinalIgnoreCase))
            {
                //Extract credentials
                string encodedUsernamePassword = authHeader.Substring("Basic ".Length).Trim();
                Encoding encoding = Encoding.GetEncoding("iso-8859-1");
                string usernamePassword = encoding.GetString(Convert.FromBase64String(encodedUsernamePassword));
    
                int seperatorIndex = usernamePassword.IndexOf(':');
    
                var username = usernamePassword.Substring(0, seperatorIndex);
                var password = usernamePassword.Substring(seperatorIndex + 1);
    
                //you also can use this.Context.Authentication here
                if (username == "test" && password == "test")
                {
                    var user = new GenericPrincipal(new GenericIdentity("User"), null);
                    var ticket = new AuthenticationTicket(user, new AuthenticationProperties(), Options.AuthenticationScheme);
                    return Task.FromResult(AuthenticateResult.Success(ticket));
                }
                else
                {
                    return Task.FromResult(AuthenticateResult.Fail("No valid user."));
                }
            }
    
            this.Response.Headers["WWW-Authenticate"]= "Basic realm=\"yourawesomesite.net\"";
            return Task.FromResult(AuthenticateResult.Fail("No credentials."));
        }
    }
    
    public class BasicAuthenticationMiddleware : AuthenticationMiddleware<BasicAuthenticationOptions>
    {
        public BasicAuthenticationMiddleware(
           RequestDelegate next,
           IOptions<BasicAuthenticationOptions> options,
           ILoggerFactory loggerFactory,
           UrlEncoder encoder)
           : base(next, options, loggerFactory, encoder)
        {
        }
    
        protected override AuthenticationHandler<BasicAuthenticationOptions> CreateHandler()
        {
            return new BasicAuthenticationHandler();
        }
    }
    
    public class BasicAuthenticationOptions : AuthenticationOptions
    {
        public BasicAuthenticationOptions()
        {
            AuthenticationScheme = "Basic";
            AutomaticAuthenticate = true;
        }
    }
