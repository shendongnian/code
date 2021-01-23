    class Program
    {
        static void Main(string[] args)
        {
            // Base64(SHA-1(Nonce + Created + Base64(SHA-1(Password))))
    
            string nonce = "4ETItj7Xc6+9sEDT5p2UjA==";            
            string createdString = "2014-08-04T10:22:48.994Z";
            string password = "Password2014!";
                    
            string basedPassword = System.Convert.ToBase64String(SHAOneHash(Encoding.UTF8.GetBytes(password)));
            byte[] combined = buildBytes(nonce, createdString, basedPassword);
            string output = System.Convert.ToBase64String(SHAOneHash(combined));
    
            Console.WriteLine("result is: " + output); // Ug3FRXgyAaWU8SjYHRabnAkn330=
            Console.ReadKey();
        }
    
        private static byte[] buildBytes(string nonce, string createdString, string basedPassword)
        {
            byte[] nonceBytes = System.Convert.FromBase64String(nonce);    
            byte[] time = Encoding.UTF8.GetBytes(createdString);
            byte[] pwd = Encoding.UTF8.GetBytes(basedPassword);
    
            byte[] operand = new byte[nonceBytes.Length + time.Length + pwd.Length];
            Array.Copy(nonceBytes, operand, nonceBytes.Length);
            Array.Copy(time, 0, operand, nonceBytes.Length, time.Length);
            Array.Copy(pwd, 0, operand, nonceBytes.Length + time.Length, pwd.Length);
    
            return operand;
        }
    
        public static byte[] SHAOneHash(byte[] data)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(data);
                return hash;
            }
        }
    }
