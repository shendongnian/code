    private static void TestFinalize()
    {
        ClassA a = new ClassA() { X = 4 };
        Console.WriteLine("Start Garbage Collector");
        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Done");
    }
