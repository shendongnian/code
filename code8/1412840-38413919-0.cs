    var newTask = Task.Factory.StartNew(() =>
    {
        // Some code
    });
    tasks.Add(newTask);
    newTask.ContinueWith((t) =>
    {
        pbProgress.Value++;
    }, TaskScheduler.FromCurrentSynchronizationContext());
