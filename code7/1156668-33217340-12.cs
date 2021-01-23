    // Replace this with some sort of loading from config / file.
    RSAParameters keyParams = RSAKeyUtils.GetRandomKey();
    // Create the key, and a set of token options to record signing credentials 
    // using that key, along with the other parameters we will need in the 
    // token controlller.
    key = new RsaSecurityKey(keyParams);
    tokenOptions = new TokenAuthOptions()
    {
        Audience = TokenAudience,
        Issuer = TokenIssuer,
        SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.Sha256Digest)
    };
    // Save the token options into an instance so they're accessible to the 
    // controller.
    services.AddSingleton<TokenAuthOptions>(tokenOptions);
    // Enable the use of an [Authorize("Bearer")] attribute on methods and
    // classes to protect.
    services.AddAuthorization(auth =>
    {
        auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
            .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
            .RequireAuthenticatedUser().Build());
    });
