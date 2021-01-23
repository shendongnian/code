    static void Main(string[] args)
    {
        var input = "ABC12345";
        var numeric = new String(input.Where(char.IsDigit).ToArray());
        Console.Read();
    }
