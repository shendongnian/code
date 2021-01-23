    internal static ClaimsPrincipal GetClaimPrincipalFromToken(string jwtSecurityHeader)
    {
        var jwtSecurityHandler = new JwtSecurityTokenHandler();
    
        var signingCertificates = GetSigningCertificates(ConfigHelper.FederationMetadataDocument);
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidAudience = ConfigHelper.AppIdURI,
            ValidIssuer = ConfigHelper.Issuer,
            LifetimeValidator =
                (before, expires, token, parameters) =>
                {
                    //Don't allow not-yet-active tokens
                    if (before.HasValue && before.Value > DateTime.Now)
                        return false;
    
                    //If expiration has a date, add 2 days to it
                    if (expires.HasValue)
                        return expires.Value.AddDays(2) > DateTime.Now;
    
                    //Otherwise the token is valid
                    return true;
                },
            ValidateLifetime = true,
            IssuerSigningTokens = signingCertificates,
        };
    
        var headerParts = jwtSecurityHeader.Split(' ');
        if (headerParts.Length != 2 || headerParts[0] != "Bearer")
            throw new AuthorizationException(HttpStatusCode.Forbidden, "Invalid token type");
        
        var jwtSecurityToken = headerParts[1];
        SecurityToken jwtToken;
        var claimsPrincipal = jwtSecurityHandler.ValidateToken(jwtSecurityToken, tokenValidationParameters, out jwtToken);
    
        return claimsPrincipal;
    }
