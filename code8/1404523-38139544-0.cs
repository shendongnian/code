    public Task<Task> DelayExecute(Action func)
    {
        AbortCurrentTask();
        tokenSource = new CancellationTokenSource();
        cancellationToken = tokenSource.Token;
        return currentTask = Task.Factory.StartNew(async () =>
            {
                var sw = Stopwatch.StartNew();
                await Task.Delay(timeout, cancellationToken);
                func();
                Debug.WriteLine("sw.ElapsedMilliseconds inside DelayExecute: " + sw.ElapsedMilliseconds);
            });
    }
