    using System;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    
    public class Test
    {
        static void Main()
        {
            var key = new X509Certificate2("key.p12", "notasecret");
            byte[] buffer = Encoding.UTF8.GetBytes("test string");
            // This is the slightly dodgy bit...
            var rsa = (RSACryptoServiceProvider) key.PrivateKey;
            byte[] signature = rsa.SignData(buffer, "SHA256");
            Console.WriteLine(Convert.ToBase64String(signature));
        }
    }
