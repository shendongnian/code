    static void Main()
    {
        Log(F());
    }
    [ConditionalAttribute("DEBUG")]
    static void Log(string s)
    {
        Console.WriteLine(s);
    }
    static string F()
    {
        Console.WriteLine("foo");
        return "bar";
    }
