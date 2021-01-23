    #region IClientMessageInspector Members
    public void AfterReceiveReply(ref System.ServiceModel.Channels.Message   reply, object correlationState)
    {
      Console.WriteLine("IClientMessageInspector.AfterReceiveReply called.");
      Console.WriteLine("Message: {0}", reply.ToString());
    }
    public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel)
    {
       Console.WriteLine("IClientMessageInspector.BeforeSendRequest called.");
       return null;
    }
