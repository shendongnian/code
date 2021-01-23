    private Task<Tuple<E, R>> _SendCommandAndRetrieveResponseAsync(C command)
    {
        Task<Tuple<E, R>> result = //.....
        return result;
    }
    public Task<E> SendCommandAsync(C command)
    {
        return _SendCommandAndRetrieveResponseAsync(command)
            .ContinueWith(task => new TaskCompletionSource<E>(task.Result.Item1).Task)
            .Unwrap();
    }
