    public static void Main(string[] args)
    {
        string a = "test";
        string en = HashData(a);
        Console.WriteLine(en);
    }
        
    public static string HashData(string textToBeEncripted)
    {
        Byte[] byteDataToHash = System.Text.Encoding.Unicode.GetBytes(textToBeEncripted);
        Byte[] byteHashValue = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(byteDataToHash);
        System.Text.StringBuilder s = new System.Text.StringBuilder();
        foreach (var b in byteHashValue)
            s.Append(b.ToString("x2"));
        return s.ToString();
