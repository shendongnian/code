    using System.IO;
    using System;
    using System.Text;
    using System.Security.Cryptography;
    
    class Program
    {
        public static string GeneratePasswordHash(string password, string salt)
        {
           Byte[] passwordBytes = Encoding.UTF8.GetBytes(password + salt);
           Byte[] hashedBytes = new SHA256CryptoServiceProvider().ComputeHash(passwordBytes);
           return BitConverter.ToString(hashedBytes).Replace("-", String.Empty);
        }
        
        
        static void Main()
        {
            // Get from Database
            var user = new {
                HashedPassword = "C0918DCF45AFE4CB00363A7C70920841EB76AE522CAA3AA5EED3C5A020870C21",
                Salt = "apjsdm/2ascxz" // Make it random every time
            };
            
            // The password you want to verify
            string password = "12345";
            string calculatedHash  = GeneratePasswordHash(password, user.Salt);
            
            if (user.HashedPassword.Equals(calculatedHash))
            {
                Console.WriteLine("Valid Password");    
            }
            else
            {
                Console.WriteLine("Invalid Password");    
            }
        }
    }
