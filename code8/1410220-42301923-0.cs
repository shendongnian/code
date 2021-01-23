    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    public class JwtTokenValidator
        {
            public ClaimsPrincipal ValidateToken(string jwtToken)
            {
                SecurityToken securityToken;
                var validationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = "ValidTokenIssuerName",
                    ValidAudience = "ValidTokenAudienceName",
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.Default.GetBytes("ValidTokenSigningKey"))
                };
            var recipientTokenHandler = new JwtSecurityTokenHandler();
            var claimsPrincipal = recipientTokenHandler.ValidateToken(jwtToken, validationParameters, out securityToken);
            return claimsPrincipal;
        }
    } 
