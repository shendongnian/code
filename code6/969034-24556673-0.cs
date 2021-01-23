    try
    {
        ...
        client.Close();
    }
    finally
    {
        if(client.State != CommunicationState.Closed)
            client.Abort();
    }
