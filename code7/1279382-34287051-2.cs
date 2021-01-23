    static void Main(string[] args)
    {
         MsgToCode("Test");
    }
    public static void MsgToCode(string value)
    {
        var bytes = System.Text.Encoding.UTF8.GetBytes(value);
        var newBytes = new byte[bytes.Length];
        for (int i = 0; i < bytes.Length; i++)
        {
             newBytes[i] = Convert.ToByte(Convert.ToInt32(bytes[i]) + 2);
        }
        Console.WriteLine(System.Text.Encoding.UTF8.GetString(newBytes));
        Console.ReadLine();
    }
