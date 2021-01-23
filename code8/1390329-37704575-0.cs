    public class AdvancedEncryptionStandardProvider
    {
        // Private properties
        private readonly ICryptoTransform _encryptor, _decryptor;
        private UTF8Encoding _encoder;
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="key">Our shared key</param>
        /// <param name="secret">Our secret</param>
        public AdvancedEncryptionStandardProvider(string key, string secret)
        {
            // Create our encoder
            this._encoder = new UTF8Encoding();
            // Get our bytes
            var _key = _encoder.GetBytes(key);
            var _secret = _encoder.GetBytes(secret);
            // Create our encryptor and decryptor
            var managedAlgorithm = new RijndaelManaged();
            managedAlgorithm.BlockSize = 128;
            managedAlgorithm.KeySize = 128;
            this._encryptor = managedAlgorithm.CreateEncryptor(_key, _secret);
            this._decryptor = managedAlgorithm.CreateDecryptor(_key, _secret);
        }
        /// <summary>
        /// Encrypt a string
        /// </summary>
        /// <param name="unencrypted">The un-encrypted string</param>
        /// <returns></returns>
        public string Encrypt(string unencrypted)
        {
            return Convert.ToBase64String(Encrypt(this._encoder.GetBytes(unencrypted)));
        }
        /// <summary>
        /// Decrypt a string
        /// </summary>
        /// <param name="encrypted">The encrypted string</param>
        /// <returns></returns>
        public string Decrypt(string encrypted)
        {
            return this._encoder.GetString(Decrypt(Convert.FromBase64String(encrypted)));
        }
        /// <summary>
        /// Encrypt some bytes
        /// </summary>
        /// <param name="buffer">The bytes to encrypt</param>
        /// <returns></returns>
        public byte[] Encrypt(byte[] buffer)
        {
            return Transform(buffer, this._encryptor);
        }
        /// <summary>
        /// Decrypt some bytes
        /// </summary>
        /// <param name="buffer">The bytes to decrypt</param>
        /// <returns></returns>
        public byte[] Decrypt(byte[] buffer)
        {
            return Transform(buffer, this._decryptor);
        }
        /// <summary>
        /// Writes bytes to memory
        /// </summary>
        /// <param name="buffer">The bytes</param>
        /// <param name="transform"></param>
        /// <returns></returns>
        protected byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            // Create our memory stream
            var stream = new MemoryStream();
            // Write our bytes to the stream
            using (var cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
            // Retrun the stream as an array
            return stream.ToArray();
        }
    }
