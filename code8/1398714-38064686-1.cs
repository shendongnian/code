    client.OnMessage(brokeredMessage =>
    {
        try
        {
            // Process the message
            ...
           // Complete the message (depends on the )
           brokeredMessage.Complete();
        }
        catch (Exception ex)
        {
            
            Trace.TraceError("Exception captured: " + ex.Message);
            // Here you have access to the brokeredMessage so you can log what you want.
            ...    
            //Abandon the message so that it could be re-process ??
            brokeredMessage.Abandon();        
        }
    }, options);
