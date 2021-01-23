    var tasks = new Task<MyMethodReturnObject>[3];
    tasks[0] = GetFirstListFilesAsync();
    tasks[1] = GetSecondListFilesAsync();
    tasks[2] = GetThirdListFilesAsync();
    // At this point, all three tasks are running at the same time.
    // Now, we await them all.
    await Task.WhenAll(tasks);
    // Get an individual result, where result is MyMethodReturnObject
    var myText = tasks[0].Result;
    // Loop through results
    var results = tasks.Select(o => o.Result).ToList();
    foreach (var result in results)
    {
        Console.Write(result);
    }
