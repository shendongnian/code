    public Task<string> SendAndReceiveMessage(string messageToSend)
    {
        var tcs = new TaskCompletionSource<string>();
        ...
        VpnObject.OnMessageReceived += (s, e) => tcs.SetResult(e.Message);
        ...
        return tcs.Task;
    }
