    /// <summary>
    /// Contains the relevant Bouncy Castle Methods required to encrypt a password.
    /// References NuGet Package BouncyCastle.Crypto.dll
    /// </summary>
    public class BouncyCastleHashing
    {
        private SecureRandom _cryptoRandom;
        public BouncyCastleHashing()
        {
            _cryptoRandom = new SecureRandom();
        }
        /// <summary>
        /// Random Salt Creation
        /// </summary>
        /// <param name="size">The size of the salt in bytes</param>
        /// <returns>A random salt of the required size.</returns>
        public byte[] CreateSalt(int size)
        {
            byte[] salt = new byte[size];
            _cryptoRandom.NextBytes(salt);
            return salt;
        }
        /// <summary>
        /// Gets a PBKDF2_SHA256 Hash  (Overload)
        /// </summary>
        /// <param name="password">The password as a plain text string</param>
        /// <param name="saltAsBase64String">The salt for the password</param>
        /// <param name="iterations">The number of times to encrypt the password</param>
        /// <param name="hashByteSize">The byte size of the final hash</param>
        /// <returns>A base64 string of the hash.</returns>
        public string PBKDF2_SHA256_GetHash(string password, string saltAsBase64String, int iterations, int hashByteSize)
        {
            var saltBytes = Convert.FromBase64String(saltAsBase64String);
            var hash = PBKDF2_SHA256_GetHash(password, saltBytes, iterations, hashByteSize);
            return Convert.ToBase64String(hash);
        }
        /// <summary>
        /// Gets a PBKDF2_SHA256 Hash (CORE METHOD)
        /// </summary>
        /// <param name="password">The password as a plain text string</param>
        /// <param name="salt">The salt as a byte array</param>
        /// <param name="iterations">The number of times to encrypt the password</param>
        /// <param name="hashByteSize">The byte size of the final hash</param>
        /// <returns>A the hash as a byte array.</returns>
        public byte[] PBKDF2_SHA256_GetHash(string password, byte[] salt, int iterations, int hashByteSize)
        {
            var pdb = new Pkcs5S2ParametersGenerator(new Org.BouncyCastle.Crypto.Digests.Sha256Digest());
            pdb.Init(PbeParametersGenerator.Pkcs5PasswordToBytes(password.ToCharArray()), salt,
                         iterations);
            var key = (KeyParameter)pdb.GenerateDerivedMacParameters(hashByteSize * 8);
            return key.GetKey();
        }
        /// <summary>
        /// Validates a password given a hash of the correct one. (OVERLOAD)
        /// </summary>
        /// <param name="password">The original password to hash</param>
        /// <param name="salt">The salt that was used when hashing the password</param>
        /// <param name="iterations">The number of times it was encrypted</param>
        /// <param name="hashByteSize">The byte size of the final hash</param>
        /// <param name="hashAsBase64String">The hash the password previously provided as a base64 string</param>
        /// <returns>True if the hashes match</returns>
        public bool ValidatePassword(string password, string salt, int iterations, int hashByteSize, string hashAsBase64String)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] actualHashBytes = Convert.FromBase64String(hashAsBase64String);
            return ValidatePassword(password, saltBytes, iterations, hashByteSize, actualHashBytes);
        }
        /// <summary>
        /// Validates a password given a hash of the correct one (MAIN METHOD).
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <param name="correctHash">A hash of the correct password.</param>
        /// <returns>True if the password is correct. False otherwise.</returns>
        public bool ValidatePassword(string password, byte[] saltBytes, int iterations, int hashByteSize, byte[] actualGainedHasAsByteArray)
        {
            byte[] testHash = PBKDF2_SHA256_GetHash(password, saltBytes, iterations, hashByteSize);
            return SlowEquals(actualGainedHasAsByteArray, testHash);
        }
        /// <summary>
        /// Compares two byte arrays in length-constant time. This comparison
        /// method is used so that password hashes cannot be extracted from
        /// on-line systems using a timing attack and then attacked off-line.
        /// </summary>
        /// <param name="a">The first byte array.</param>
        /// <param name="b">The second byte array.</param>
        /// <returns>True if both byte arrays are equal. False otherwise.</returns>
        private bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }
    }
