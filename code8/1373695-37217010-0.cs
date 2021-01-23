    static void Main(string[] args)
    {
        using (var aes = System.Security.Cryptography.AesManaged.Create())
        {
            aes.GenerateKey();
        }
    }
