        public bool ValidateJasonWebToken(string fullKey, string jwtToken)
        {
            try
            {
                var rs256Token = fullKey.Replace("-----BEGIN PUBLIC KEY-----", "");
                rs256Token = rs256Token.Replace("-----END PUBLIC KEY-----", "");
                rs256Token = rs256Token.Replace("\n", "");
                Validate(jwtToken, rs256Token);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        private void Validate(string token, string key)
        {
            var keyBytes = Convert.FromBase64String(key); // your key here
            AsymmetricKeyParameter asymmetricKeyParameter = PublicKeyFactory.CreateKey(keyBytes);
            RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)asymmetricKeyParameter;
            RSAParameters rsaParameters = new RSAParameters
            {
                Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned(),
                Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned()
            };
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaParameters);
                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = false,
                    RequireSignedTokens = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    IssuerSigningKey = new RsaSecurityKey(rsa)
                };
                var handler = new JwtSecurityTokenHandler();
                var result = handler.ValidateToken(token, validationParameters, out var validatedToken);
            }
        }
