    private IEnumerable<Claim> ValidateToken(string token)
    {
        //Grab certificate for verifying JWT signature
        //IdentityServer4 also has a default certificate you can might reference.
        //In prod, we'd get this from the certificate store or similar
        var certPath = Path.Combine(Server.MapPath("~/bin"), "SscSign.pfx");
        var cert = new X509Certificate2(certPath);
        var x509SecurityKey = new X509SecurityKey(cert);
        var parameters = new TokenValidationParameters
        {
            RequireSignedTokens = true,
            ValidAudience = audience,
            ValidIssuer = validIssuer,
            IssuerSigningKey = x509SecurityKey,
            RequireExpirationTime = true,
            ClockSkew = TimeSpan.FromMinutes(5)
        };
        //Validate the token and retrieve ClaimsPrinciple
        var handler = new JwtSecurityTokenHandler();
        SecurityToken jwt;
        var id = handler.ValidateToken(token, parameters, out jwt);
        //Discard temp cookie and cookie-based middleware authentication objects (we just needed it for storing State)
        this.Request.GetOwinContext().Authentication.SignOut("TempCookie");
        return id.Claims;
    }
