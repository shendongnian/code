    public static void X(out int i)
    {
        i = 10;
    }
    static void Main(string[] args)
    {
        int y;
        X(out y);
        Console.WriteLine(y);
    }
