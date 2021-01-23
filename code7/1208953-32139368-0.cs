        private string DecryptValue(string input, string textkey)
        {
            // Declare the static initialization vector
            var iv = new byte[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            // Convert the properties to required buffers
            var pwBuffer = CryptographicBuffer.ConvertStringToBinary(textkey, BinaryStringEncoding.Utf8);
            var saltBuffer = CryptographicBuffer.CreateFromByteArray(iv);
            var buffer = CryptographicBuffer.DecodeFromBase64String(input);
            // Load the alghorithm providers
            var symmetricKeyProvider = SymmetricKeyAlgorithmProvider.OpenAlgorithm("AES_CBC");
            // Create the symmetric key that is used to encrypt the string from IV
            var cryptoKey = symmetricKeyProvider.CreateSymmetricKey(pwBuffer);
            // Decrypt the IBuffer back to byte array
            var resultBuffer = CryptographicEngine.Decrypt(cryptoKey, buffer, saltBuffer);
            // Get string back from the byte array
            var decryptedString = CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, resultBuffer);
            // Return plain text
            return decryptedString;
        }
