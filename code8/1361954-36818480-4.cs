    public bool IsRunning
    {
        get
        {
            return task.Status == TaskStatus.Running;
        }
    }
    public void Start()
    {
        tokenSource = new CancellationTokenSource();
        CancellationToken token = tokenSource.Token;
        task = Task.Run(async () =>
        {
            while (true)
            {
                CheckForStateChange(token);
                token.ThrowIfCancellationRequested();
                await Task.Delay(1000); // Pause 1 second before checking state again
            }
        }, token);
        // Uncomment this and step through `CheckForStateChange`.
        // When the execution hangs, you'll know what's causing the
        // postbacks to the UI thread and *may* be able to take it out.
        // task.Wait();
    }
