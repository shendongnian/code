    [Conditional("DEBUG")]
    public static void DebugWaitAKey(string message = "Press any key")
    {
        Console.WriteLine(message);
        if(!UnitTestDetector.IsInUnitTest)
            Console.ReadKey();
    }
