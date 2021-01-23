    public async Task ExecuteAsync(Action action, CancellationToken token)
    {
        var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(token);
        var task = _decoratedPolicy.ExecuteAsync(action, linkedTokenSource.Token);
        var completed = await Task.WhenAny(task, Task.Delay(_timeout));
        if (completed != task)
        {
            linkedTokenSource.Cancel();//Try to cancel the method
            throw new TimeoutException("The task did not complete within the TimeoutExecutionPolicy window of" + _timeout + "ms");
        }
    }
