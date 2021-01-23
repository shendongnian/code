    // https://github.com/aspnet/Security/blob/master/src/Microsoft.AspNetCore.Authentication.JwtBearer/Events/IJwtBearerEvents.cs
    // http://codereview.stackexchange.com/questions/45974/web-api-2-authentication-with-jwt
    public class TokenMaker
    {
        class SecurityConstants
        {
            public static string TokenIssuer;
            public static string TokenAudience;
            public static int TokenLifetimeMinutes;
        }
        public static string IssueToken()
        {
            SecurityKey sSKey = null;
            var claimList = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, "userName"),
                new Claim(ClaimTypes.Role, "role")     //Not sure what this is for
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor desc = makeSecurityTokenDescriptor(sSKey, claimList);
            // JwtSecurityToken tok = tokenHandler.CreateJwtSecurityToken(desc);
            return tokenHandler.CreateEncodedJwt(desc);
        }
        
        public static ClaimsPrincipal ValidateJwtToken(string jwtToken)
        {
            SecurityKey sSKey = null;
            var tokenHandler = new JwtSecurityTokenHandler();
            // Parse JWT from the Base64UrlEncoded wire form 
            //(<Base64UrlEncoded header>.<Base64UrlEncoded body>.<signature>)
            JwtSecurityToken parsedJwt = tokenHandler.ReadToken(jwtToken) as JwtSecurityToken;
            TokenValidationParameters validationParams =
                new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidAudience = SecurityConstants.TokenAudience,
                    ValidIssuers = new List<string>() { SecurityConstants.TokenIssuer },
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = sSKey,
                    
                };
            SecurityToken secT;
            return tokenHandler.ValidateToken("token", validationParams, out secT);
        }
        private static SecurityTokenDescriptor makeSecurityTokenDescriptor(SecurityKey sSKey, List<Claim> claimList)
        {
            var now = DateTime.UtcNow;
            Claim[] claims = claimList.ToArray();
            return new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = SecurityConstants.TokenIssuer,
                Audience = SecurityConstants.TokenAudience,
                IssuedAt = System.DateTime.UtcNow,
                Expires = System.DateTime.UtcNow.AddMinutes(SecurityConstants.TokenLifetimeMinutes),
                NotBefore = System.DateTime.UtcNow.AddTicks(-1),
                SigningCredentials = new SigningCredentials(sSKey, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.EcdsaSha512Signature)
            };
            
        }
    }
