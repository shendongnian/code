    var principal = new JwtSecurityTokenHandler().ValidateToken(jwtheader,
                            new TokenValidationParameters()
                            {
                                RequireExpirationTime = true,
                                ValidAudience = audience,
                                ValidIssuer = issuer,
                                IssuerSigningKey = new InMemorySymmetricSecurityKey(secret)
                            }, out token);
