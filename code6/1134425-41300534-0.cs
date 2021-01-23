        public static string Sign(this X509Certificate2 x509, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            byte[] signedData;
            using (MD5 hasher = MD5.Create())
            {
                RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)x509.PrivateKey;
                signedData = rsa.SignData(data, hasher);
            }
            return Convert.ToBase64String(signedData);// +Environment.NewLine + Environment.NewLine; 
            //return ByteArrayToString(signedData); //Convert.ToBase64String(signedData);
        }
