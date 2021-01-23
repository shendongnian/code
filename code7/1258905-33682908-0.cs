    private readonly ConcurrentQueue<WorkItem> _Items
        = new ConcurrentQueue<WorkItem>();
    private CancellationTokenSource _CancelSource;
    public async Task Submit(IEnumerable<WorkItem> items)
    {
        var cancel = ReplacePreviousTasks();
        foreach (var item in items)
        {
            _Items.Enqueue(item);
        }
        await Task.Delay(TimeSpan.FromMilliseconds(250), cancel.Token);
        if (!cancel.IsCancellationRequested)
        {
            await RunOperation();
        }
    }
    private CancellationTokenSource ReplacePreviousTasks()
    {
        var cancel = new CancellationTokenSource();
        var old = Interlocked.Exchange(ref _CancelSource, cancel);
        if (old != null)
        {
            old.Cancel();
        }
        return cancel;
    }
    private async Task RunOperation()
    {
        var items = new List<WorkItem>();
        WorkItem item;
        while (_Items.TryDequeue(out item))
        {
            items.Add(item);
        }
        // do the operation on items
    }
