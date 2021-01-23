    public static void MsgToCode(string value)
    {
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(value);
        var sb = new StringBuilder();
        foreach (var item in bytes)
        {
            sb.Append((Convert.ToInt32(item) + 2));
        }
        Console.WriteLine(sb.ToString());
        Console.ReadLine();
    }
