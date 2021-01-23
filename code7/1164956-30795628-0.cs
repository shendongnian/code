    class Program
    {
        static void Main(string[] args)
        {
            string key, iv;
            var plain="A very secret message.";
            var cipher=EncryptString(plain, out key, out iv);
            // Later ...
            var message=DecryptString(cipher, key, iv);
        }
        public static string EncryptString(string plain, out string key, out string iv)
        {
            var crypto=new DataEncryptor();
            iv=Convert.ToBase64String(crypto.IV);
            key=Convert.ToBase64String(crypto.Key);
            return crypto.EncryptString(plain);
        }
        public static string DecryptString(string cipher, string key, string iv)
        {
            var crypto=new DataEncryptor(
                Convert.FromBase64String(key), 
                Convert.FromBase64String(iv));
            return crypto.DecryptString(cipher);
        }
    }
