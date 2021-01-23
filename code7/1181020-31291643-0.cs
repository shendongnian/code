    public void OpenConnection(string strUrl)
    {
      var myBinding = new BasicHttpBinding();
      var myEndpoint = new EndpointAddress(strUrl);
      var myChannelFactory = new ChannelFactory<IMyService>(myBinding, myEndpoint);
    
      IMyService client = null;
    
      try
      {
        client = myChannelFactory.CreateChannel();
        client.MyServiceOperation();
        ((ICommunicationObject)client).Close();
      }
      catch
      {
       //...
      }
    }
