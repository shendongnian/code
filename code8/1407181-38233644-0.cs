    public class GoogleJsonWebToken
    {
        public static string Encode(string uid)
        {
            var firebaseInfPath = HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["firebaseInf"]);
            var firebaseInfJsonContent = File.ReadAllText(firebaseInfPath);
            var firebaseInf = JsonConvert.DeserializeObject<dynamic>(firebaseInfJsonContent);
            // NOTE: Replace this with your actual RSA public/private keypair!
            var provider = new RSACryptoServiceProvider(2048);
            var parameters = provider.ExportParameters(true);
            // Build the credentials used to sign the JWT
            var signingKey = new RsaSecurityKey(parameters);
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.RsaSha256);
            // Create a collection of optional claims
            var now = DateTimeOffset.UtcNow;
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, firebaseInf.client_email),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                new Claim("uid", uid, ClaimValueTypes.String), 
                new Claim("premium_account", "true", ClaimValueTypes.Boolean)
            };
            
            // Create and sign the JWT, and write it to a string
            var jwt = new JwtSecurityToken(
                issuer: firebaseInf.client_email,
                audience: "https://identitytoolkit.googleapis.com/google.identity.identitytoolkit.v1.IdentityToolkit",
                claims: claims,
                expires: now.AddMinutes(60).DateTime,
                signingCredentials: signingCredentials);
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
