    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    using Microsoft.Owin.Security;
    public class JwtTokenFormatter : ISecureDataFormat<AuthenticationTicket>
        {
            private readonly JwtSecurityTokenHandler _tokenHandler;
            public JwtTokenFormatter()
            {
                _tokenHandler = new JwtSecurityTokenHandler();
    
            }
            public string Protect(AuthenticationTicket data)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Audience = "ValidTokenAudienceName",
                    Issuer = "ValidTokenIssuerName",
                    IssuedAt = DateTime.UtcNow,
                    NotBefore = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddHours(24),
                    Subject = data.Identity,
                    SigningCredentials =
                        new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.Default.GetBytes("ValidTokenSigningKey")),
                            SecurityAlgorithms.HmacSha256Signature)
                };
    
                return _tokenHandler.CreateEncodedJwt(tokenDescriptor);
            }
    
            public AuthenticationTicket Unprotect(string protectedText)
            {
                throw new NotImplementedException();
            }
        }
