    var cts = new CancellationTokenSource();
    // two minutes in milliseconds
    cts.CancelAfter(2000 * 60);
    var tasks = new List<Task>();
    foreach (var item in items)
    {
        // this is needed because of closures work in C#
        var localItem = item;
        tasks.Add(Task.Run(() => 
            { /* a process with a localItem here */ 
                // this check should be repeated from time to time in your calculations
                if (cts.Token.IsCancellationRequested)
                {
                    cts.Token.ThrowIfCancellationRequested();
                }
            }
        // all tasks has only one token
        , cts.Token)
    
    }
    // this will cancel all tasks after 2 minutes from start
    Task.WaitAll(tasks.ToArray(), TimeSpan.FromMinutes(2));
    // this will cancel all tasks if one of them will last more than 2 minutes
    Task.WaitAll(tasks.ToArray());
