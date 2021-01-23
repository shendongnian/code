    public class AuthRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    /// <summary>
    /// Request a new token for a given username/password pair.
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    [HttpPost]
    public dynamic Post([FromBody] AuthRequest req)
    {
        // Obviously, at this point you need to validate the username and password against whatever system you wish.
        if ((req.username == "TEST" && req.password == "TEST") || (req.username == "TEST2" && req.password == "TEST"))
        {
            DateTime? expires = DateTime.UtcNow.AddMinutes(2);
            var token = GetToken(req.username, expires);
            return new { authenticated = true, entityId = 1, token = token, tokenExpires = expires };
        }
        return new { authenticated = false };
    }
    private string GetToken(string user, DateTime? expires)
    {
        var handler = new JwtSecurityTokenHandler();
        // Here, you should create or look up an identity for the user which is being authenticated.
        // For now, just creating a simple generic identity.
        ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(user, "TokenAuth"), new[] { new Claim("EntityID", "1", ClaimValueTypes.Integer) });
        var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor() {
            Issuer = tokenOptions.Issuer,
            Audience = tokenOptions.Audience,
            SigningCredentials = tokenOptions.SigningCredentials,
            Subject = identity,
            Expires = expires
        });
        return handler.WriteToken(securityToken);
    }
