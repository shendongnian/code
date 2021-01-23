        using System.Security.Cryptography;
        public static string GenerateAPIKey()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] apiKey = new byte[32];
            rng.GetBytes(apiKey);
            string s = System.Convert.ToBase64String(apiKey);
            return s;
        }
