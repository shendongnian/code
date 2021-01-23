    private void TestArray()
    {
        // Setup the Array
        ChainLink[] Test = new ChainLink[1000000];
        for (int i = 0; i < 1000000; i++)
            Test[i] = new ChainLink();
        // Use a Stopwatch to measure time
        Stopwatch SW;
        SW = new Stopwatch();
        SW.Start();
        // Go through items in the array
        for (int i = 0; i < Test.Length; i++)
            Test[i].Foo();
        // Stop timer and report results
        SW.Stop();
        Console.WriteLine(SW.Elapsed);
    }
