    public class GoogleJsonWebToken
    {
        public const string SCOPE_DRIVE_READONLY = "https://www.googleapis.com/auth/drive.readonly";
        public const string SCOPE_DRIVE = "https://www.googleapis.com/auth/drive";
        public static dynamic GetAccessToken(string clientIdEMail, string keyFilePath, string scope)
        {
            // certificate
            var certificate = new X509Certificate2(keyFilePath, "notasecret");
            // header
            var header = new { typ = "JWT", alg = "RS256" };
            // claimset
            var times = GetExpiryAndIssueDate();
            var claimset = new
            {
                iss = clientIdEMail,
                scope = scope,
                aud = "https://accounts.google.com/o/oauth2/token",
                iat = times[0],
                exp = times[1],
            };
            JavaScriptSerializer ser = new JavaScriptSerializer();
            // encoded header
            var headerSerialized = ser.Serialize(header);
            var headerBytes = Encoding.UTF8.GetBytes(headerSerialized);
            var headerEncoded = Convert.ToBase64String(headerBytes);
            // encoded claimset
            var claimsetSerialized = ser.Serialize(claimset);
            var claimsetBytes = Encoding.UTF8.GetBytes(claimsetSerialized);
            var claimsetEncoded = Convert.ToBase64String(claimsetBytes);
            // input
            var input = headerEncoded + "." + claimsetEncoded;
            var inputBytes = Encoding.UTF8.GetBytes(input);
            // signiture
            var rsa = certificate.PrivateKey as RSACryptoServiceProvider;
            var cspParam = new CspParameters
            {
                KeyContainerName = rsa.CspKeyContainerInfo.KeyContainerName,
                KeyNumber = rsa.CspKeyContainerInfo.KeyNumber == KeyNumber.Exchange ? 1 : 2
            };
            var aescsp = new RSACryptoServiceProvider(cspParam) { PersistKeyInCsp = false };
            var signatureBytes = aescsp.SignData(inputBytes, "SHA256");
            var signatureEncoded = Convert.ToBase64String(signatureBytes);
            // jwt
            var jwt = headerEncoded + "." + claimsetEncoded + "." + signatureEncoded;
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            var uri = "https://accounts.google.com/o/oauth2/token";
            var content = new NameValueCollection();
            content["assertion"] = jwt;
            content["grant_type"] = "urn:ietf:params:oauth:grant-type:jwt-bearer";
            string response = Encoding.UTF8.GetString(client.UploadValues(uri, "POST", content));
            var result = ser.Deserialize<dynamic>(response);
            return result;
        }
        private static int[] GetExpiryAndIssueDate()
        {
            var utc0 = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var issueTime = DateTime.UtcNow;
            var iat = (int)issueTime.Subtract(utc0).TotalSeconds;
            var exp = (int)issueTime.AddMinutes(55).Subtract(utc0).TotalSeconds;
            return new[] { iat, exp };
        }
    }
