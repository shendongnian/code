    string sessionId = Guid.NewGuid().ToString(); 
    [...]
    // put message in sync queue
    var message = new BrokeredMessage(request)
    {
       ReplyToSessionId = sessionId
    };
    await ServiceBusConnector.Instance.SyncClient.SendAsync(message);
    
    // now listen to reply on session response queue (only accepts message on same session id)
    MessageSession session = await ServiceBusConnector.Instance.SyncResponseClient.AcceptMessageSessionAsync(sessionId);
    
    BrokeredMessage responseMessage = await session.ReceiveAsync(TimeSpan.FromMinutes(5));
    await responseMessage.CompleteAsync();
    await session.CloseAsync();
    
    Response response = responseMessage.GetBody<Response>();
    // process Worker Role's response
