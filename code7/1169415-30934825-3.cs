    private void TestChainLink()
    {
        // Setup the linked list
        ChainLink Test = new ChainLink();
        for (int i = 0; i < 1000000; i++)
        {
            Test.nextLink = new ChainLink();
            Test = Test.nextLink;
        }
        // Use a Stopwatch to measure time
        Stopwatch SW;
        SW = new Stopwatch();
        SW.Start();
        // Go through items in the linked list
        while (Test != null)
        {
            Test.Foo();
            Test = Test.nextLink;
        }
        // Stop timer and report results
        SW.Stop();
        Console.WriteLine(SW.Elapsed);
    }
