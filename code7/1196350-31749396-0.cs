    static void Main(string[] args)
    {
        byte[] lolempty = new byte[1024];
        string encoded = Encoding.ASCII.GetString(lolempty);
        Console.WriteLine(encoded.Length.ToString());
        Console.WriteLine("[{0}]", encoded);
    }
