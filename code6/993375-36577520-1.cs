    public enum Codes
    {
        A = 1,
        B = 2,
        C = 3
    }
    static void Main(string[] args)
    {
        Console.WriteLine(IntToEnum<Codes?>(1));
        Console.WriteLine(IntToEnum<Codes?>(null));
        Console.WriteLine(IntToEnum<Codes>(2));
    }
