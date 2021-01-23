    var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("test"));
    var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
    var securityTokenDescriptor = new SecurityTokenDescriptor()
    {
        Subject = new ClaimsIdentity(new List<Claim>()
        {
            new Claim(ClaimTypes.NameIdentifier, "johndoe@example.com"),
            new Claim(ClaimTypes.Role, "Administrator"),
        }, "Custom"),
        NotBefore = DateTime.Now,
        SigningCredentials = signingCredentials,
        Issuer = "self",
        IssuedAt = DateTime.Now,
        Expires = DateTime.Now.AddHours(3),
        Audience = "http://my.website.com"
    };
    var tokenHandler = new JwtSecurityTokenHandler();
    var plainToken = tokenHandler.CreateToken(securityTokenDescriptor);
    var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);
