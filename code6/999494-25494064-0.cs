    static void Main(string[] args)
    {
        PHPRef.AddService test = new PHPRef.AddService();
    
        var pkey = test.getPublicKey();
        byte[] pkeybyte = GetBytes(pkey);
    
        X509Certificate2 cert = new X509Certificate2();
        cert.Import(pkeybyte);
    
        RSACryptoServiceProvider rsa = (RSACryptoServiceProvider)cert.PublicKey.Key;
    
        byte[] encryptedData = rsa.Encrypt(GetBytes("password"), false);
    
        Console.WriteLine(GetString(encryptedData));
    
        string answer = test.getDecrypted((sbyte[])(Array)encryptedData);
    
        Console.WriteLine(answer);
    
        Console.ReadLine();
    
    }
