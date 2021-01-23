    class SOPasswordHasher
    {
        /// <summary>
        /// Password Hasher
        /// </summary>
        /// <param name="password">The password you want to hash</param>
        /// <param name="salt">byte array of (crypto-secure) random values</param>
        /// <param name="iterations">Number of iterations. default is 60,000</param>
        /// <returns>Byte array containing the hashed password</returns>
        public static byte[] Hash(string password, byte[] salt, int iterations = 60000)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                // step 2
                byte[] hash = sha256.ComputeHash(passwordBytes.Concat(salt).ToArray());
                // step 3
                byte[] result = sha256.ComputeHash(salt.Concat(hash).ToArray());
                // step 4
                for (int i = 0; i < iterations; i++)
                {
                    result =
                        sha256.ComputeHash(salt.Concat(result).ToArray());
                }
                return result;
            }
        }
        public static byte[] GetSalt(int size = 32)
        {
            byte[] salt = new byte[size];
            using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                cryptoServiceProvider.GetBytes(salt);
            }
            return salt;
        }
    }
