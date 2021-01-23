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
            var newValue = Convert.ToInt32(bytes[i]) + 2;
            if (newValue > 255)
                newValue -= 255;
            newBytes[i] = Convert.ToByte(newValue);
        }
        Console.WriteLine(System.Text.Encoding.UTF8.GetString(newBytes));
        Console.ReadLine();
    }
