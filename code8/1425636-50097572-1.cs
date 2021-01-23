        		private JwtSecurityToken GenerateJWT()
        		{
        
        var securityKey = new Microsoft.IdentityModel.Tokens.X509SecurityKey(GetByThumbprint("YOUR-CERT-THUMBPRINT-HERE"));
    
    var JWTHeader = new JwtHeader(credentials);
        
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials
            				  (securityKey, "RS256");
        
        			var payload = new JwtPayload
        			{
        
        				{ "iss", "Issuer-here"},
        				{ "exp", (Int32)(DateTime.UtcNow.AddHours(1).Subtract(new DateTime(1970, 1, 1))).TotalSeconds},
        				{ "iat", (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds}
        
        			};
        
        			var token = new JwtSecurityToken(JWTHeader, payload);
        			return token;
        		}
