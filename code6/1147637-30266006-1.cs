      static void Main(string[] args)
        {
            string hashed = "YOSGtSkJ41KX7K80FEmg+vme4ioLsp3qr28XU8nDQ9c=";
            for (int i = 1000; i <=9999; i++)
            {
                string digit = i.ToString().PadLeft(4, '0');
                string s = ComputeSHA256(digit);
                if (s == hashed)
                {
                    Console.WriteLine(digit + "is my decrypted hash");
                    break;
                }
            }
            Console.ReadKey();
        }
        static string ComputeSHA256(string plainText)
        {
             SHA256Managed sha256Managed = new SHA256Managed();
            Encoding u16LE = Encoding.Unicode;
            string hash = String.Empty;
            byte[] hashed = sha256Managed.ComputeHash(u16LE.GetBytes(plainText), 0, u16LE.GetByteCount(plainText));
            return Convert.ToBase64String(hashed);
        }
