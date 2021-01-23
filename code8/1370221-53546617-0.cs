    var properties = new AuthenticationProperties(new Dictionary<string, string>
    {
    {
    "audience", string.Empty
    }
    });
        
    var ticket = new AuthenticationTicket(identity, properties)
    {
    Properties =
    {
    IssuedUtc = DateTime.UtcNow,
    ExpiresUtc = DateTime.UtcNow.AddMinutes(Config.TokenLifeSpan)
    };
        
    var accessToken = new ApplicationJwtFormat(Config.Issuer).Protect(ticket);
    var expiresIn = Config.TokenLifeSpan * 60 - 1;
        
    var token = new OAuthSuccessResponse(accessToken, "bearer", Convert.ToInt32(expiresIn), null);
    return Content(HttpStatusCode.OK, token);
----------
        public OAuthSuccessResponse(string accessToken, string tokenType, int expiresIn, string refreshToken)
        {
            access_token = accessToken;
            token_type = tokenType;
            expires_in = expiresIn;
            refresh_token = refreshToken;
        }
