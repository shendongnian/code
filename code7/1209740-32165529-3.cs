    using System.IO;
    using System;
    using System.Text;
    using System.Security.Cryptography;
    
    class Program
    {
        static void Main()
        {
            byte[] bytes = new UnicodeEncoding().GetBytes("Hello");
            String s =  Convert.ToBase64String(new SHA256Managed().ComputeHash(bytes));
            Console.WriteLine(s);
        }
    }
