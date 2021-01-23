    var list = Enumerable.Range(0, 1000).ToList();
    
    list
    .Select(x=>x)  // !
    .AsParallel().AsOrdered().ForAll(i =>
    {
        Task.Delay(1000).Wait();
        Console.WriteLine(i);
    });
