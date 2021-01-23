    public static void Main(string[] args)
    {
        Console.WriteLine(GetLength("\t"));
        Console.WriteLine(GetLength("\t foobar"));
        Console.WriteLine(GetLength(String.Format("\t {0, -15}", "Hello World")));
        Console.WriteLine(GetLength("a\t"));
        Console.ReadLine();
    }
    private static int GetLength(string str)
    {
        return str.Replace("\t", "    ").Length;
    }
