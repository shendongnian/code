    static void Main()
    {
        string s;
        if (Environment.TickCount > 0)
            s = "A";
        else
            s = "B";
        Console.WriteLine(s);
    }
