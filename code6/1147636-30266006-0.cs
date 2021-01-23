      static void Main(string[] args)
        {
            string hashed = "YOSGtSkJ41KX7K80FEmg+vme4ioLsp3qr28XU8nDQ9c=";
            for (int i = 1000; i <=9999; i++)
            {
                string s = ComputeSHA256(i.ToString() + "your salt");
                if (s == hashed)
                {
                    Console.WriteLine(i + "is my decrypted hash");
                    break;
                }
            }
            Console.ReadKey();
        }
        static string ComputeSHA256(string plainText)
        {
            SHA256Managed sha256 = new SHA256Managed();
            string hash = String.Empty;
            byte[] hashed = sha256.ComputeHash(Encoding.ASCII.GetBytes(plainText),0,Encoding.ASCII.GetByteCount(plainText));
           
            foreach (byte bit in hashed)
            {
                hash += bit.ToString("x2");
            }
            return hash;
        }
