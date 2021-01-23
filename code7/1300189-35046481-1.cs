    public Task JoinChatSession()
    {
        //get user SessionId to allow use multiple tabs
        var sessionId = ChatSessionHelper.GetChatSessionId();
        if (string.IsNullOrEmpty(sessionId)) throw new InvalidOperationException("No chat session id");
        return Groups.Add(Context.ConnectionId, sessionId);
    }
