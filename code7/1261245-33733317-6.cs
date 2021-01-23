    static void Main()
    {
        string s = null;
        if (Environment.TickCount > 0)
            s = "A";
        else
            s = "B";
        Console.WriteLine(s);
    }
