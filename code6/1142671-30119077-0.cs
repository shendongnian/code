    using System;
    using System.IO;
    using System.Security.Cryptography;
    
    namespace AesDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] key = null;
                byte[] iv = null;
                byte[] bytesToEncrypt = null;
                byte[] encryptedBytes = null;
                byte[] decryptedBytes = null;
    
                // generate key and iv to use for encryption/decryption. 
                using (RijndaelManaged aesAlg = new RijndaelManaged())
                {
                    aesAlg.GenerateKey();
                    aesAlg.GenerateIV();
                    key = aesAlg.Key;
                    iv = aesAlg.IV;
                }
    
                // original bytes
                bytesToEncrypt = File.ReadAllBytes(@"c:\exe");
                Console.WriteLine("Bytes read: {0}",bytesToEncrypt.Length);
    
                // encrypt
                encryptedBytes = CryptoAes.Encrypt(bytesToEncrypt, key, iv);
                Console.WriteLine("Encrypted bytes length: {0}", encryptedBytes.Length);
    
                // decrypt
                decryptedBytes = CryptoAes.Decrypt(encryptedBytes, key, iv);
                Console.WriteLine("Decrypted bytes length: {0}", decryptedBytes.Length);
    
                // compare
                Console.WriteLine("Decrypted bytes same as original bytes: {0}", Convert.ToBase64String(decryptedBytes) == Convert.ToBase64String(bytesToEncrypt));
                Console.ReadLine();
            }
        }
    
        internal sealed class CryptoAes
        {
            /// <summary>
            /// Encrypts data with symetric key
            /// </summary>
            /// <param name="data">Data to be encrypted</param>
            /// <param name="key">Symetric key</param>
            /// <param name="iv">Initialization vector</param>
            /// <returns>Encrypted data</returns>
            public static byte[] Encrypt(byte[] data, byte[] key, byte[] iv)
            {
                byte[] encryptedData = null;
    
                if (data == null)
                    throw new ArgumentNullException("data");
    
                if (data == key)
                    throw new ArgumentNullException("key");
    
                if (data == iv)
                    throw new ArgumentNullException("iv");
    
                using (RijndaelManaged aesAlg = new RijndaelManaged())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = iv;
    
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    encryptedData = encryptor.TransformFinalBlock(data, 0, data.Length);
                }
    
                return encryptedData;
            }
    
            /// <summary>
            /// Decrypts data with symetric key
            /// </summary>
            /// <param name="data">Encrypted data</param>
            /// <param name="key">Symetric key</param>
            /// <param name="iv">Initialization vector</param>
            /// <returns>Decrypted data</returns>
            public static byte[] Decrypt(byte[] data, byte[] key, byte[] iv)
            {
                byte[] decryptedData = null;
    
                if (data == null)
                    throw new ArgumentNullException("data");
    
                if (data == key)
                    throw new ArgumentNullException("key");
    
                if (data == iv)
                    throw new ArgumentNullException("iv");
    
                using (RijndaelManaged aesAlg = new RijndaelManaged())
                {
                    aesAlg.Key = key;
                    aesAlg.IV = iv;
    
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    decryptedData = decryptor.TransformFinalBlock(data, 0, data.Length);
                }
    
                return decryptedData;
            }
        }
    }
