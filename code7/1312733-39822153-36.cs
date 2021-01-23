    var tokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        // The signing key must match!
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = signingKey,
        // Validate the JWT Issuer (iss) claim
        ValidateIssuer = true,
        ValidIssuer = "ExampleIssuer",
        // Validate the JWT Audience (aud) claim
        ValidateAudience = true,
        ValidAudience = "ExampleAudience",
        // Validate the token expiry
        ValidateLifetime = true,
        // If you want to allow a certain amount of clock drift, set that here:
        ClockSkew = TimeSpan.Zero, 
    };
