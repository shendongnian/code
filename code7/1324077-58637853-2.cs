    private static string GetSha1Hash(string key, string base)
        {
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyBytes = encoding.GetBytes(key);
            byte[] messageBytes = encoding.GetBytes(base);
            string strSignature = string.Empty;
            using (HMACSHA1 SHA1 = new HMACSHA1(keyBytes))
            {
                var Hashed = SHA1.ComputeHash(messageBytes);
                strSignature = Convert.ToBase64String(Hashed);
            }
            return strSignature;
        }
