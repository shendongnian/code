    class Program
    {
        private static byte[] AES_Key = { 42, 95, 203, 23, 145, 210, 47, 182, 2, 69, 179, 216, 54, 158, 208, 178, 194, 115, 113, 86, 63, 191, 31, 60, 158, 223, 107, 17, 130, 90, 93, 10 };
        static void Main(string[] args)
        {
            // Get bytes of AES Key, read contents
            var contentsBytes = File.ReadAllBytes("profile.sii");
            
            // Create IV & Cipher test byte arrays
            var iv = new byte[0x10];
            var cipherText = new byte[contentsBytes.Length - 0x38];
            // Copy contents bytes to cipherText & IV arrays
            Array.Copy(contentsBytes, 56, cipherText, 0, cipherText.Length);
            Array.Copy(contentsBytes, 36, iv, 0, iv.Length);
            // Create AES Crypto Service Provider with our Key & Vector.
            var cryptoServiceProvider = new AesCryptoServiceProvider
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.None,
                KeySize = 0x80,
                BlockSize = 0x80,
                Key = AES_Key,
                IV = iv
            };
            // Create decryptor and get plain text of encrypted contents.
            var decryptor = cryptoServiceProvider.CreateDecryptor();
            var plainText = decryptor.TransformFinalBlock(cipherText, 0, cipherText.Length);
            
            string decompressedContents;
            // Load into Memory Stream and skip the first 2 bytes.
            // Use a Deflate stream to decompress the contents
            // Read the deflated contents via our StreamReader
            using (var memStream = new MemoryStream(plainText, 2, plainText.Length - 2))
            using (var iis = new DeflateStream(memStream, CompressionMode.Decompress))
            using (var streamReader = new StreamReader(iis))
            {
                decompressedContents = streamReader.ReadToEnd();
            }
        }
    }
