        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
        TokenValidationParameters validationParameters = new TokenValidationParameters
        {
            ValidAudience = audience,
            ValidIssuer = issuer,
            IssuerSigningTokens = signingTokens,
            CertificateValidator = X509CertificateValidator.None
        };
        try
        {
            // Validate token.
            SecurityToken validatedToken = new JwtSecurityToken();
            ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(jwtToken, validationParameters, out validatedToken);
            // Do other validation things, like making claims available to controller...
        }
        catch (SecurityTokenValidationException)
        {
            // Token validation failed
            HttpResponseMessage response = BuildResponseErrorMessage(HttpStatusCode.Unauthorized);
            return response;
        }
