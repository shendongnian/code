    static void Main(string[] args)
    {
        const string SimplifiedChineseChars = "冈区色呆";
        byte[] bytes = Encoding.GetEncoding("gb2312") // vanilla gb2312 encoding
                .GetBytes(SimplifiedChineseChars)
                .Select(b => (byte)(b & 0x7F)) // retain 7 bits only
                .ToArray();
        string hex = BitConverter.ToString(bytes).Replace("-", "_");
        Console.WriteLine(hex);
    }
