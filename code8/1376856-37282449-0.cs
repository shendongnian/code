    namespace Sandbox
    {
        class Program
        {
            static void Main(string[] args)
            {
                var originString = "This is some example text";
    
                var originBytes = System.Text.Encoding.UTF8.GetBytes(originString);
    
                var aes = new AesCryptoServiceProvider {KeySize = 256};
                aes.GenerateIV();
                aes.GenerateKey();
                var vectorBytes = aes.IV;
                var keyBytes = aes.Key;
    
                //Not going to use these in the code, but here's how to get the values if you
                //Want to save them off.
                var vectorString = System.Text.Encoding.UTF8.GetString(vectorBytes);
                var keyString = System.Text.Encoding.UTF8.GetString(keyBytes);
    
                var encryptedBytes = EncryptionService.Encrypt(keyBytes, vectorBytes, originBytes);
    
                var encyptedString = System.Text.Encoding.UTF8.GetString(encryptedBytes);
    
                var decryptedBytes = EncryptionService.Decrypt(keyBytes, vectorBytes, encryptedBytes);
    
                var decryptedString = System.Text.Encoding.UTF8.GetString(decryptedBytes);
    
                Console.WriteLine($"Origin:\t\t {originString}");
                Console.WriteLine($"Vector:\t\t {vectorString}");
                Console.WriteLine($"Key:\t\t {keyString}");
                Console.WriteLine($"Encrypted:\t {encyptedString}");
                Console.WriteLine($"Decrypted:\t {decryptedString}");
    
                Console.ReadLine();
                
            }
        }
    
        public static class EncryptionService
        {
            public static byte[] Encrypt(byte[] key, byte[] vector, byte[] input)
            {
                if (key.Length == 0)
                    throw new ArgumentException("Cannot encrypt with empty key");
    
                if (vector.Length == 0)
                    throw new ArgumentException("Cannot encrypt with empty vector");
    
                if (input.Length == 0)
                    throw new ArgumentException("Cannot encrypt empty input");
    
                var unencryptedBytes = input;
    
                using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider { Key = key, IV = vector })
                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream writer = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    writer.Write(unencryptedBytes, 0, unencryptedBytes.Length);
                    writer.FlushFinalBlock();
                    var byteArray = ms.ToArray();
    
                    if (byteArray.Length == 0)
                        throw new Exception("Attempted to encrypt but encryption resulted in a byte array of 0 length.");
    
                    return byteArray;
                }
            }
    
    
            public static byte[] Decrypt(byte[] key, byte[] vector, byte[] encrypted)
            {
                if (key.Length == 0)
                    throw new ArgumentException("Cannot encrypt with empty key");
    
                if (vector.Length == 0)
                    throw new ArgumentException("Cannot encrypt with empty vector");
    
                if (encrypted == null || encrypted.Length == 0)
                    throw new ArgumentException("Cannot decrypt empty or null byte array");
    
                byte[] unencrypted;
    
                using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider { Key = key, IV = vector })
                using (ICryptoTransform decryptor = aes.CreateDecryptor(key, vector))
                using (MemoryStream ms = new MemoryStream(encrypted))
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    var decrypted = new byte[encrypted.Length];
                    var bytesRead = cs.Read(decrypted, 0, encrypted.Length);
    
                    return decrypted.Take(bytesRead).ToArray();
                }
    
            }
        }
    }
