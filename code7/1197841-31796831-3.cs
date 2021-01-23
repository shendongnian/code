    MessageHeaders headers = OperationContext.Current.IncomingMessageHeaders;
    try
    {
        Guid clientId = headers.GetHeader<Guid>("Identity", "http://www.MyCustomNamespace.com");
        if (clientId == new Guid("5DBD6E89-81F2-4786-BC93-2758A8368A5D")
        {
            //TODO: this is our target client, do your stuff here...
        }
    }
    catch (Exception)
    {
    }
