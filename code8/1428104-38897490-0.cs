    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Security.Cryptography;
    using System.IO;
    using System.ComponentModel;
    
    namespace final_encryption
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
    
                    string original = "{50602604|U800EDE73F241AC2E58A7D74C879D1D77|4DB6C4}"; //"Here is some data to encrypt!";
                    Console.WriteLine("Original:   " + original);
                    Console.ReadLine();
    
                    // Create a new instance of the RijndaelManaged
                    // class.  This generates a new key and initialization 
                    // vector (IV).
                    byte[] key = new byte[16];
                    for (int i = 0; i < 16; ++i)
                    {
                        key[i] = 1;
                    }
    
                    byte[] iv = new byte[16];
                    for (int i = 0; i < 16; ++i)
                    {
                        iv[i] = 1;
                    }
                    using (RijndaelManaged myRijndael = new RijndaelManaged())
                    {
                        // myRijndael.GenerateKey();
                        //myRijndael.GenerateIV();
                        myRijndael.Key = key;
                        myRijndael.IV = iv;
                        // Encrypt the string to an array of bytes.
                        byte[] encrypted = EncryptStringToBytes(original, myRijndael.Key, myRijndael.IV);
    
                        StringBuilder s = new StringBuilder();
                        foreach (byte item in encrypted)
                        {
                            s.Append(item.ToString("X2") + " ");
                        }
                        Console.WriteLine("Encrypted:   " + s);
                        Console.ReadLine();
    
                        // Decrypt the bytes to a string.
                        string decrypted = DecryptStringFromBytes(encrypted, myRijndael.Key, myRijndael.IV);
    
                        //Display the original data and the decrypted data.
                        Console.WriteLine("Decrypted:    " + decrypted);
                        Console.ReadLine();
                    }
    
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                    Console.ReadLine();
    
                }
            }
            static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
            {
                // Check arguments.
                if (plainText == null || plainText.Length <= 0)
                    throw new ArgumentNullException("plainText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("Key");
                byte[] encrypted;
                // Create an RijndaelManaged object
                // with the specified key and IV.
                using (RijndaelManaged rijAlg = new RijndaelManaged())
                {
                    rijAlg.Key = Key;
                    rijAlg.IV = IV;
                    rijAlg.Mode = CipherMode.CBC;
                    rijAlg.Padding = PaddingMode.Zeros;
    
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);
    
                    // Create the streams used for encryption.
                    using (MemoryStream msEncrypt = new MemoryStream())
                    {
                        using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                            {
    
    
    
                                //Write all data to the stream.
    
                                swEncrypt.Write(plainText);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }
    
    
                // Return the encrypted bytes from the memory stream.
                return encrypted;
    
            }
    
            static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
            {
                // Check arguments.
                if (cipherText == null || cipherText.Length <= 0)
                    throw new ArgumentNullException("cipherText");
                if (Key == null || Key.Length <= 0)
                    throw new ArgumentNullException("Key");
                if (IV == null || IV.Length <= 0)
                    throw new ArgumentNullException("Key");
    
                // Declare the string used to hold
                // the decrypted text.
                string plaintext = null;
    
                // Create an RijndaelManaged object
                // with the specified key and IV.
                using (RijndaelManaged rijAlg = new RijndaelManaged())
                {
                    rijAlg.Key = Key;
                    rijAlg.IV = IV;
                    rijAlg.Mode = CipherMode.CBC;
                    rijAlg.Padding = PaddingMode.Zeros;
    
                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
    
                    // Create the streams used for decryption.
                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
    
                                // Read the decrypted bytes from the decrypting stream
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
    
                }
    
                return plaintext;
            }
        }
    }
