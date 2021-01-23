    private string GenerateToken(string userName)
    {
        var someClaims = new Claim[]{
            new Claim(JwtRegisteredClaimNames.UniqueName, userName),
            new Claim(JwtRegisteredClaimNames.Email, GetEmail(userName)),
            new Claim(JwtRegisteredClaimNames.NameId,Guid.NewGuid().ToString())
        };
        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Tokenizer.Key));
        var token = new JwtSecurityToken(
            issuer: _settings.Tokenizer.Issuer,
            audience: _settings.Tokenizer.Audience,
            claims: someClaims,
            expires: DateTime.Now.AddHours(_settings.Tokenizer.ExpiryHours),
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
