    public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel, InstanceContext instanceContext)
    {
        var bufferedCopy = request.CreateBufferedCopy(2000000); // choose a suitable buffer size
        request = bufferedCopy.CreateMessage();// Message for continued processing
        
        var messageToRead = bufferedCopy.CreateMessage(); // message to read properties from
        return null;
    }
