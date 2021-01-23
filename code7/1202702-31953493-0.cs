    config.TokenValidationParameters.SignatureValidator =
                    delegate (string token, TokenValidationParameters parameters)
                    {
                        var clientSecret = "not the real secret";
                        var jwt = new JwtSecurityToken(token);
                        var raw = jwt.RawData;
                        var hmac = new HMACSHA256(Convert.FromBase64String(clientSecret));
                        var signingCredentials = new SigningCredentials(
                           new SymmetricSecurityKey(hmac.Key), SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha256Digest);
                        var signKey = signingCredentials.SigningKey as SymmetricSecurityKey;
                        var encodedData = jwt.EncodedHeader + "." + jwt.EncodedPayload;
                        var compiledSignature = Encode(encodedData, signKey.Key);
                        if (compiledSignature != jwt.RawSignature)
                        {
                            return null;
                        }
                        return jwt;
                    };
