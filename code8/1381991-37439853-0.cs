        public static string Encript(string strData)
        {
            string hashValue = HashData(strData);
            return hashValue;
        }
        public static string HashData(string textToBeEncripted)
        {
            //Convert the string to a byte array
            Byte[] byteDataToHash = System.Text.Encoding.Unicode.GetBytes(textToBeEncripted);
            //Compute the MD5 hash algorithm
            Byte[] byteHashValue = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(byteDataToHash);
            return BitConverter.ToString(byteHashValue).Replace("-", "");
        }
