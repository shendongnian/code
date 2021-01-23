    public async Task ExecuteAsync(Action action, CancellationToken token)
    {
        var task = _decoratedPolicy.ExecuteAsync(action, token);
        var completed = await Task.WhenAny(task, Task.Delay(_timeout));
        if (completed != task)
        {
            throw new TimeoutException("The task did not complete within the TimeoutExecutionPolicy window of" + _timeout + "ms");
        }
    }
