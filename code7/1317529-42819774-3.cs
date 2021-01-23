    var validationParameters = new TokenValidationParameters()
    {
         ValidateAudience = true,
         ValidAudience = "http://my.website.com",
         ValidateIssuer = true,
         ValidIssuer = "self",
         ValidateIssuerSigningKey = true,
         IssuerSigningKey = signingKey,
         RequireExpirationTime = true,
         ValidateLifetime = true,
         ClockSkew = TimeSpan.Zero
    };
    try
    {
        SecurityToken mytoken = new JwtSecurityToken();
        var myTokenHandler = new JwtSecurityTokenHandler();
        var myPrincipal = myTokenHandler.ValidateToken(signedAndEncodedToken, validationParameters, out mytoken);
    } catch (Exception ex)
    {
        System.Diagnostics.Debug.WriteLine("Authentication failed");
    }
