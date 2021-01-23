    using System;
    using System.Text;
    
    namespace ConsoleApplication
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var apiKey = "SBB3aWxsIG1ha2UgbXbcQVBJIHN|Y3VyZQ==";
                var apiSecret = "QaTW3xlf1U5ljdlAJSdltzT71fFF+eZ=";
                var key = Convert.FromBase64String(apiSecret);
                Console.Write("key:");
                prtByte(key);
    
                Console.Write("Pre-hash:");
                prtByte(Encoding.UTF8.GetBytes(apiKey));
                var provider = new System.Security.Cryptography.HMACSHA256(key);
                var hash = provider.ComputeHash(Encoding.UTF8.GetBytes(apiKey));
                Console.Write("hash:");
                prtByte(hash);
    
                var signature = Convert.ToBase64String(hash);
                Console.WriteLine("signature:" + signature);
            }
            public static void prtByte(byte[] b)
            {
                for (var i = 0; i < b.Length; i++)
                {
                    Console.Write(b[i].ToString("x2"));
                }
                Console.WriteLine();
            }
        }
    }
