    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Selectors;
    using System.IdentityModel.Tokens;
    using System.Security.Claims;
    using System.ServiceModel.Security.Tokens;
    using System.Text;
    namespace SO25372035
    {
        class Program
        {
            static void Main()
            {
                const string tokenString =  @"eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJodHRwczovL3NlY3VyZS5leGFtcGxlLmNvbS8iLCJleHAiOjE0MTA4MTkzODAsImh0dHA6Ly9leGFtcGxlLmNvbS9vcmdudW0iOiI5ODc5ODc5ODciLCJodHRwOi8vZXhhbXBsZS5jb20vdXNlciI6Im1lQGV4YW1wbGUuY29tIiwiaWF0IjoxNDA4NDE5NTQwfQ.jW9KChUTcgXMDp5CnTiXovtQZsN4X-M-V6_4rzu8Zk8";
                JwtSecurityToken tokenReceived = new JwtSecurityToken(tokenString);
                byte[] keyBytes = Encoding.UTF8.GetBytes("secret");
                if (keyBytes.Length < 64 && tokenReceived.SignatureAlgorithm == "HS256")
                {
                    Array.Resize(ref keyBytes, 64);
                }
                TokenValidationParameters validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    AudienceUriMode = AudienceUriMode.Never,
                    SigningToken = new BinarySecretSecurityToken(keyBytes),
                };
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(tokenReceived, validationParameters);
                IEnumerable<Claim> a = claimsPrincipal.Claims;
                foreach (var claim in a)
                {
                    Console.WriteLine(claim);
                }
            }
        }
    }
