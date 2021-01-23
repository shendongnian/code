    public Task<string> SendAndReceiveMessage(string messageToSend)
    {
        var tcs = new TaskCompletionSource<string>();
        ...
        VpnObject.OnMessageReceived(message => tcs.SetResult(message));
        ...
        return tcs.Task;
    }
