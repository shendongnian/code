    var context = app.ApplicationServices.GetService<SimpleContext>();
    app.UseSimpleTokenProvider(new TokenProviderOptions
    {
        Path = "/api/token",
        Audience = "ExampleAudience",
        Issuer = "ExampleIssuer",
        SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
        IdentityResolver = (username, password) => GetIdentity(context, username, password)
    });
