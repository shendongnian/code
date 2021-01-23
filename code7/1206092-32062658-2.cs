    public void RegisterClient()
    {
        IService1Callback callback = OperationContext.Current.GetCallbackChannel<IService1Callback>();
        var sessionId = OperationContext.Current.SessionId;
        if (!clients.ContainsKey(sessionId))
        {
           clients.Add(sessionId, callback);
        }
    }
 
