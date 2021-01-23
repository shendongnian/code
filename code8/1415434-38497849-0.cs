    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.IdentityModel.Tokens;
    
    namespace ConsoleApplication10
    {
        class Program
        {
            static void Main(string[] args)
            {
                GenereToken();
    
            }
    
    
            public static void GenereToken()
            {
    
                var certThumbPrint = "95 2f 5e ca 7c d0 a3 f0 6c ca 7d e4 0a 24 7a 2c c3 42 f5 f6";
                X509Store certStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                certStore.Open(OpenFlags.ReadOnly);
                X509Certificate2Collection certCollection = certStore.Certificates.Find(X509FindType.FindByThumbprint, certThumbPrint, false);
                certStore.Close();
    
                var securityKey = new X509SecurityKey(certCollection[0]);
                var algorithm = "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";
                var header = new JwtHeader(new Microsoft.IdentityModel.Tokens.SigningCredentials(securityKey, algorithm));
    
                var payload = new JwtPayload
                {
                    {"iss", "a5ghgde64-e8g4d-48ga-beg1-56e293d09a69"},
                    {"scope", "example.com"},
                    {"aud", "example.com"},
                    {"iat", 1441698079},
                };
    
                var secToken = new JwtSecurityToken(header, payload);
    
                var handler = new JwtSecurityTokenHandler();
    
                var cielToken = handler.WriteToken(secToken);
    
            }
        }
    }
