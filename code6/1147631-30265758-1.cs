    namespace Examen
    {
        class Program
        {
            static void Main(string[] args)
            {
                string hashed_password = "YOSGtSkJ41KX7K80FEmg+vme4ioLsp3qr28XU8nDQ9c=";
                int index;
                for(index = 0; i <= 9999; i++)
                {
                    if (hashed_password.Equals(sha256_hash(i.ToString().PadLeft(4,'0')))
                        break;                            
                }
                Console.WriteLine("Password is: " + index.ToString().PadLeft(4,'0'));
                Console.ReadLine();
            }
            public static String sha256_hash(String value) {
                using (SHA256 hash = SHA256Managed.Create()) {
                return String.Join("", hash
                    .ComputeHash(Encoding.UTF8.GetBytes(value))
                    .Select(item => item.ToString("x2")));
            }
        } 
     }
 
