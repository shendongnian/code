    using System;
    using System.Linq;
    
    namespace EncryptStringSample
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Please enter a password to use:");
                string password = Console.ReadLine();
                Console.WriteLine("Please enter a string to encrypt:");
                string plaintext = Console.ReadLine();
                Console.WriteLine("");
    
                Console.WriteLine("Your encrypted string is:");
                string encryptedstring = StringCipher.Encrypt(plaintext, password);
                Console.WriteLine(encryptedstring);
                Console.WriteLine("");
    
                Console.WriteLine("Your decrypted string is:");
                string decryptedstring = StringCipher.Decrypt(encryptedstring, password);
                Console.WriteLine(decryptedstring);
                Console.WriteLine("");
    
                Console.ReadLine();
            }
        }
    }
