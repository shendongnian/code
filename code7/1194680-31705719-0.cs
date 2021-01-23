    async Task DisplayPrimeCounts()
    {
        for (int i = 0; i < 10; i++)
        {
            var value = await SomeExpensiveComputation(i);
            Console.WriteLine(value);
        }
        Console.WriteLine("Done!");
    }
