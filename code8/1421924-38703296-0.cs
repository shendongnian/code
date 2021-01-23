    private const string AUDIANCE = "<GUID of your Audiance>";
    private const string TENANT = "<GUID of your Tenant>";
    private static async Task<SecurityToken> validateJwtTokenAsync(string token)
    {
        // Build URL based on your AAD-TenantId
        var stsDiscoveryEndpoint = String.Format(CultureInfo.InvariantCulture, "https://login.microsoftonline.com/{0}/.well-known/openid-configuration", TENANT);
        // Get tenant information that's used to validate incoming jwt tokens
        var configManager = new ConfigurationManager<OpenIdConnectConfiguration>(stsDiscoveryEndpoint);
        // Get Config from AAD:
        var config = await configManager.GetConfigurationAsync();
        // Validate token:
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidAudience = AUDIANCE,
            ValidIssuer = config.Issuer,
            IssuerSigningTokens = config.SigningTokens,
            CertificateValidator = X509CertificateValidator.ChainTrust,
        };
        var validatedToken = (SecurityToken)new JwtSecurityToken();
        // Throws an Exception as the token is invalid (expired, invalid-formatted, etc.)
        tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
        return validatedToken;
    }
