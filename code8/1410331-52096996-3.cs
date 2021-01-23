    protected string GetName(string token)
		{
			string secret = "this is a string used for encrypt and decrypt token"; 
			var key = Encoding.ASCII.GetBytes(secret);
			var handler = new JwtSecurityTokenHandler();
			var validations = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuer = false,
				ValidateAudience = false
			};
			var claims = handler.ValidateToken(token, validations, out var tokenSecure);
			return claims.Identity.Name;
		}
