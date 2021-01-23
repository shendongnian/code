    void Main()
    {
        DoSomething(msg => Console.WriteLine(msg));
    
        using (var writer = new StreamWriter(@"d:\temp\test.txt"))
        {
            DoSomething(msg => writer.WriteLine(msg));
        }
    }
    
    public delegate void LogDelegate(string message);
    
    public static void DoSomething(LogDelegate logger)
    {
        logger("Starting");
        for (int index = 0; index < 10; index++)
            logger("Processing element #" + index);
        logger("Finishing");
    }
