    public async Task<string> ReceivedMessage()
    {
        await string Received = ReceiveFromVpnAsync(); //replace with the code the sends and waits for the response.
        // Some VPN Code  and then return the result;
        return Received;
    }
    public async string SendAndReceiveMessageAsync(string MessageToSend)
    {
        string result = string.Empty;
        // Now Sending Message through the VPN
        VpnObject.SendMessage(MessageToSend);
        //Then want to Receieve the answer and return the answer here .
        Task<string> sendReceive = ReceivedMessage();
    
        result = await sendReceive;
   
        return result;
    }
