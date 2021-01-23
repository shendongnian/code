    public void Send(string message)
    {
        //get user chat session id
        var sessionId = ChatSessionHelper.GetChatSessionId();
        if (string.IsNullOrEmpty(sessionId)) throw new InvalidOperationException("No chat session id");
        //now message will appear in all tabs
        Clients.Group(sessionId).addNewMessageToPage(message);
    }
