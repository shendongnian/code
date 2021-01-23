    static void Main(string[] args)
    {
        var counters = PerformanceCounterCategory.GetCategories()
            .SelectMany(x=>x.GetCounters("")).Where(x => x.CounterName.Contains("GPU"));
        foreach (var counter in counters)
        {
            Console.WriteLine("{0} - {1}", counter.CategoryName, counter.CounterName);
        }
        Console.ReadLine();
    }
