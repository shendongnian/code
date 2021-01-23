    var tasks = Enumerable.Range(1, 10).Select(async d =>
    {
        Console.Out.WriteLine("Processing [{0}]", d);
        await Task.Delay(5000); // Simulate IO work. Here will be some web service calls taking 7/8+ seconds.
        Console.Out.WriteLine("Task Complete [{0}]", d);
        return (2*d).ToString();
    }).ToList();
    var results = Task.WhenAll(tasks).Result;
    Console.Out.WriteLine("All processing were complete with results: {0}", string.Join("|", results));
