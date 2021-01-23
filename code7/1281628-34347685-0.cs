    static void Main(string[] args)
    {
        const string SimplifiedChineseChars = "冈区色呆";
        byte[] bytes = Encoding.GetEncoding("hz-gb-2312").GetBytes(SimplifiedChineseChars);
        string hex = BitConverter.ToString(bytes).Replace("-", "_");
        Console.WriteLine(hex);
    }
