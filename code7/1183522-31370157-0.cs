    public async Task<string> RecievedMessage()
    {
        await string Recieved;
        // Some VPN Code  and then return the result;
        return Recieved;
    }
    public async string SendAndRecieveMessageAsync(string MessageToSend)
    {
        string RecievedAnswer = string.Empty;
        // Now Sending Message through the VPN
        VpnObject.SendMessage(MessageToSend);
        //Then want to Recieve the answer and return the answer here .
        Task<string> sendReceive= RecievedMessage();
    
        string result = await sendReceive;
   
        return result;
    }
