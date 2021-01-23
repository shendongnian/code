    private void TestList()
    {
        // Setup the list
        List<ChainLink> Test = new List<ChainLink>();
        for (int i = 0; i < 1000000; i++)
            Test.Add(new ChainLink());
        // Use a Stopwatch to measure time
        Stopwatch SW;
        SW = new Stopwatch();
        SW.Start();
        // Go through items in the list
        for (int i = 0; i < Test.Count; i++)
            Test[i].Foo();
        // Stop timer and report results
        SW.Stop();
        Console.WriteLine(SW.Elapsed);
    }
