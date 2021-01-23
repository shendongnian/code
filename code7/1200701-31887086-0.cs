    public static async Task WhenAll(
        IEnumerable<Task> tasks,
        CancellationToken cancellationToken,
        int millisecondsTimeOut)
    {
        var cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        var timeoutTask = Task.Delay(millisecondsTimeOut, cancellationTokenSource.Token);
        var completedTask = await Task.WhenAny(Task.WhenAll(tasks), timeoutTask);
        if (completedTask == timeoutTask)
        {
            throw new TimeoutException();
        }
        cancellationTokenSource.Cancel();
        await completedTask;
    }
