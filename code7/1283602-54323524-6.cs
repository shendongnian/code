        private TokenValidationParameters GetTokenValidationParameters(string key)
        {
            var rs256Token = key.Value.Replace("-----BEGIN PUBLIC KEY-----", "");
            rs256Token = rs256Token.Replace("-----END PUBLIC KEY-----", "");
            rs256Token = rs256Token.Replace("\n", "");
            var keyBytes = Convert.FromBase64String(rs256Token);
            var asymmetricKeyParameter = PublicKeyFactory.CreateKey(keyBytes);
            var rsaKeyParameters = (RsaKeyParameters)asymmetricKeyParameter;
            var rsaParameters = new RSAParameters
            {
                Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned(),
                Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned()
            };
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportParameters(rsaParameters);
            var validationParameters = new TokenValidationParameters()
            {
                RequireExpirationTime = false,
                RequireSignedTokens = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                IssuerSigningKey = new RsaSecurityKey(rsa),
            };
            return validationParameters;
        }
