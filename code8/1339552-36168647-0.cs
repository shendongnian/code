    public class LoginResult
    {
        public string RedirectUrl { get; set; }
        public string FailureMsg { get; set; }
        public MonkeyBusiness AuthToken { get; set; }
    }
    [
        HttpPost,
        AllowAnonymous,
        Route("api/[controller]/login")
    ]
    public async Task<LoginResult> Login(
        [FromBody] CredentialsModel credentials,
        [FromServices] ILogger logger,
        [FromServices] IAuthenticationModule authentication,
        [FromServices] IAuthClaimsPrincipalBuiler claimsPrincipalBuilder)
    {
        try
        {
            var result = 
                await authentication.ExternalAuthenticateAsync(credentials);
            if (result.IsAuthenticated)
            {
                var principal = 
                    await claimsPrincipalBuilder.BuildAsync(credentials);
                await HttpContext.Authentication.SignInAsync("Scheme", principal);
                return new LoginResult 
                {
                    AuthToken = 
                        "Too much source to make up just for stackoverflow, " +
                        "but I hope you now get the point..."
                };
            }
            return new LoginResult { FailureMsg = "Invalid credentials." };
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message, ex);
            return new LoginResult { FailureMsg = ex.Message };
        }
    }
