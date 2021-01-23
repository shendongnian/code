    public Task<string> ReceivedMessage()
    {
        string Received; //get the response from the VPN Object.
        var ts = new TaskCompletionSource<string>();
        ts.SetResult(Received);
        // Some VPN Code  and then return the result;
        return ts.Task;
    }
    public async Task<string> SendAndReceiveMessageAsync(string MessageToSend)
    {
        string result = string.Empty;
        // Now Sending Message through the VPN
        VpnObject.SendMessage(MessageToSend);
        result = await ReceivedMessage();
   
        return result;
    }
