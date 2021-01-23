    private static void PerformComputations()
    {
        lock (lockObject)
        {
            Parallel.For(0, 500, i =>
            {
                Console.WriteLine(i);
            });
        }
    }
