    public async Task<string> GenerateTokenAsync(string email)
    {
    	var user = await _userManager.FindByEmailAsync(email);
    	var tokenHandler = new JwtSecurityTokenHandler();
    	var key = Encoding.ASCII.GetBytes(_tokenProviderOptions.SecretKey);
    
    	var userRoles = await _userManager.GetRolesAsync(user);
    	var roles = userRoles.Select(o => new Claim(ClaimTypes.Role, o));
    
    	var claims = new[]
    	{
    		new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
    		new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    		new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.CurrentCulture)),
    		new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
    		new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
    		new Claim(JwtRegisteredClaimNames.Email, user.Email),
    	}
    	.Union(roles);
    
    	var tokenDescriptor = new SecurityTokenDescriptor
    	{
    		Subject = new ClaimsIdentity(claims),
    		Expires = DateTime.UtcNow.AddHours(_tokenProviderOptions.Expires),
    		SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    	};
    
    	var token = tokenHandler.CreateToken(tokenDescriptor);
    
    	return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token)).Result;
    }
