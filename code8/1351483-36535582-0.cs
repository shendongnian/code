    class Program {
        static void Main(string[] args) {
            // get key and salt from 
            var keyRecord = EncryptionKeyManager.GetKeyRecord();
            var aesSha256Encryptor = new AesSha256Encryptor(keyRecord.SharedKey, keyRecord.HmacKey);
            string targetData = "4343423343";
            
            var encrypted =  aesSha256Encryptor.Encrypt(targetData);
            var salt = keyRecord.Salt;
            var decrypted = Decrypt(encrypted, salt);
            Debug.Assert(targetData == decrypted);
            Console.WriteLine(decrypted);
            Console.ReadKey();
           
        }
        private static string Decrypt(string data, string salt) {
            var passphraseKey = KeyManager.GetKeyFromPassphrase(EncryptionKeyManager.GetSharedPassphrase(), salt);            
            var hmacKey = KeyManager.GetKeyFromPassphrase(EncryptionKeyManager.GetClientPassphrase(), salt);
            var aesSha256Encryptor = new AesSha256Encryptor(passphraseKey, hmacKey);
            var plaintext = aesSha256Encryptor.Decrypt(data);
            return plaintext;
        }
    }
