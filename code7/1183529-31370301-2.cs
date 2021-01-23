    public async Task<string> SendAndReceiveMessage(string messageToSend)
    {
        var tcs = new TaskCompletionSource<string>();
        ...
        while(!VpnObject.IsMessageReceived)
            await Task.Delay(500); // Adjust to a reasonable polling interval
        ...
        return VpnObject.Message;
    }
