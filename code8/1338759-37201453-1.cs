        public JwtTokenProvider(string authority)
        {
            _authority = authority;
        }
        public async Task<TokenResult> GetTokenAsync(string clientId, string resource)
        {
            return await Task.FromResult(new TokenResult
            {
                AccessTokenType = "Bearer",
                IdToken = CreateJwt(clientId, resource)
            });
        }
        private string CreateJwt(string clientId, string resource)
        {
            var certificate = new X509Certificate2(Resource.notification, CertPassword);
            var sub = new System.Security.Claims.Claim("sub", clientId);
            var jti = new System.Security.Claims.Claim("jti", Guid.NewGuid().ToString());
            var claims = new List<System.Security.Claims.Claim>() { sub, jti };
            var x509Key = new X509AsymmetricSecurityKey(certificate);
            var signingCredentials = new SigningCredentials(x509Key, SecurityAlgorithms.RsaSha256Signature,
                SecurityAlgorithms.Sha256Digest);
            var jwt = new JwtSecurityToken(_authority, resource, claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(ExpirationInMinutes), signingCredentials);
            var sign = new SignatureProviderFactory();
            var provider = sign.CreateForSigning(x509Key, SecurityAlgorithms.RsaSha256Signature);
            var input = string.Join(".", new[] { jwt.EncodedHeader, jwt.EncodedPayload });
            var signed = provider.Sign(Encoding.UTF8.GetBytes(input));
            sign.ReleaseProvider(provider);
            return string.Join(".", new[] { jwt.EncodedHeader, jwt.EncodedPayload, Base64UrlEncoder.Encode(signed) });
        }
