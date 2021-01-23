    var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
                {
                    Subject = claimsIdentity,
                    Audience = allowedAudience,
                    Issuer = issuerName,
                    Expires = DateTime.MaxValue,
                    SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                        new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(symmetricKey), //symmetric key
                        System.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature,
                        System.IdentityModel.Tokens.SecurityAlgorithms.Sha256Digest)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
