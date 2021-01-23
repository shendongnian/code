    var tasks = new Task<string>[] { ToStringAsync(1) };
    Task.WhenAll(tasks)
        .ContinueWith(r =>
           {
                Console.WriteLine(r.Result.First());
                Console.ReadLine();
            })
        .Wait();
