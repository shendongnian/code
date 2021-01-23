    private readonly List<Tuple<string, TaskCompletionSource<object>> _currentLogQueue = ...; 
    public Task LogAsync(string logText)
    {
        var tcs = new TaskCompletionSource<object>();
        lock (_currentLogQueue)
        {
            _currentLogQueue.Add(Tuple.Create(logText, tcs));
        }
        return tcs.Task;
    }
    // (Within SendQueue)
    var message = queueElement.Item1;
    var tcs = queueElement.Item2;
    try
    {
      SendMessage(message);
      tcs.TrySetResult(null);
    }
    catch (Exception ex)
    {
      tcs.TrySetException(ex);
    }
