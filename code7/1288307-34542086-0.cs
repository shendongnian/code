        static TripleDESCryptoServiceProvider desCrytoProvider = new TripleDESCryptoServiceProvider();
        static MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();
        static void Main(string[] args)
        {
            String key = "29CEDC4A435DD625";//(key)
            String encodedText = Encrypt("just4fun", key);
            Console.WriteLine(Decrypt(encodedText, key));
        }
        public static String Encrypt(String text, String key)
        {
            byte[] byteHash;
            byte[] byteBuff;
            var bytes = Encoding.UTF8.GetBytes(key);
            byteHash = hashMD5Provider.ComputeHash(bytes);
            desCrytoProvider.Key = byteHash;
            desCrytoProvider.Mode = CipherMode.ECB;
            byteBuff = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(desCrytoProvider.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
        }
        public static String Decrypt(String encodedText, String key)
        {
            byte[] byteHash;
            byte[] byteBuff;
            var bytes = Encoding.UTF8.GetBytes(key);
            byteHash = hashMD5Provider.ComputeHash(bytes);
            desCrytoProvider.Key = byteHash;
            desCrytoProvider.Mode = CipherMode.ECB;
            byteBuff = Convert.FromBase64String(encodedText);
            return Encoding.UTF8.GetString(desCrytoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
        }
