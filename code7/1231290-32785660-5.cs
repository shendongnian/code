    using System;
    using System.Security.Cryptography;
    using System.Text;
    public string ComputeHash(string plainText, byte[] salt, int hash)
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
            switch (hash)
            {
                case 1:
                    using (SHA256Managed sha2 = new SHA256Managed())
                    {
                        hashValue = sha2.ComputeHash(plainDataAndSalt);
                    }
                    break;
                case 2:
                    using (SHA384Managed sha2 = new SHA384Managed())
                    {
                        hashValue = sha2.ComputeHash(plainDataAndSalt);
                    }
                    break;
                case 3:
                    using (SHA512Managed sha2 = new SHA512Managed())
                    {
                        hashValue = sha2.ComputeHash(plainDataAndSalt);
                    }
                    break;
            }
            int hashLength = hashValue.Length;
            byte[] result = new byte[hashLength + saltLength];
            Array.Copy(hashValue, 0, result, 0, hashLength);
            Array.Copy(saltBytes, 0, result, hashLength, saltLength);
            return ByteArrayToHexString(result);
        }
    private string ByteArrayToHexString(byte[] bytes)
        {
            char[] c = new char[bytes.Length * 2];
            int b;
            for (int i = 0; i < bytes.Length; i++)
            {
                b = bytes[i] >> 4;
                c[i * 2] = (char)(55 + b + (((b - 10) >> 31) & -7));
                b = bytes[i] & 0xF;
                c[i * 2 + 1] = (char)(55 + b + (((b - 10) >> 31) & -7));
            }
            return new string(c);
        }
