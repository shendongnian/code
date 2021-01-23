    var rand = new Random();
    var importedData = new List<string>();
    var results = new ConcurrentQueue<string>();
    var tasks = new List<Task<string>>
    {
        new Task<string>(() =>
        {
            Thread.Sleep(rand.Next(1000, 5000));
            Debug.WriteLine("Task 1 Completed");
            return "ABC";
        }),
        new Task<string>(() =>
        {
            Thread.Sleep(rand.Next(1000, 5000));
            Debug.WriteLine("Task 2 Completed");
            return "FOO";
        }),
        new Task<string>(() =>
        {
            Thread.Sleep(rand.Next(1000, 5000));
            Debug.WriteLine("Task 3 Completed");
            return "BAR";
        })
    };
    tasks.ForEach(t =>
    {
        t.ContinueWith(r => results.Enqueue(r.Result));
        t.Start();
    });
    var allTasksCompleted = new AutoResetEvent(false);
    new Timer(state =>
    {
        var timer = (Timer) state;
        string item;
        if (!results.TryDequeue(out item)) 
            return;
        importedData.Add(item);
        Debug.WriteLine("Imported " + item);
        if (importedData.Count == tasks.Count)
        {
            timer.Dispose();
            Debug.WriteLine("Completed.");
            allTasksCompleted.Set();
        }
    }).Change(1000, 100);
