    using System;
    using System.Security.Cryptography;
    using System.Text;
    public string ComputeHash(string plainText, byte[] salt = null)
        {
            int minSaltLength = 4;
            int maxSaltLength = 16;
            byte[] saltBytes = null;
            if (salt != null)
            {
                saltBytes = salt;
            }
            else
            {
                Random r = new Random();
                int len = r.Next(minSaltLength, maxSaltLength);
                saltBytes = new byte[len];
                using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
                {
                    rng.GetNonZeroBytes(saltBytes);
                }
            }
            byte[] plainData = ASCIIEncoding.UTF8.GetBytes(plainText);
            int plainLength = plainData.Length;
            int saltLength = saltBytes.Length;
            byte[] plainDataAndSalt = new byte[plainLength + saltLength];
            Array.Copy(plainData, 0, plainDataAndSalt, 0, plainLength);
            Array.Copy(saltBytes, 0, plainDataAndSalt, plainLength, saltLength);
            byte[] hashValue = null;
            using (SHA256Managed sha2 = new SHA256Managed())
            {
                 hashValue = sha2.ComputeHash(plainDataAndSalt);
            }
            int hashLength = hashValue.Length;
            byte[] result = new byte[hashLength + saltLength];
            Array.Copy(hashValue, 0, result, 0, hashLength);
            Array.Copy(saltBytes, 0, result, hashLength, saltLength);
            return ASCIIEncoding.UTF8.GetString(result);
        }
