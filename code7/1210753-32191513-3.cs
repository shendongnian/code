    public async Task<Result> SomeAction(int selection)
    {
            IService client = null;
            Result result = null;
            Response response = null;
            using (var myChannelFactory = SetChannelFactory(selection))
            {
                 try
                 {
                      client = myChannelFactory.CreateChannel();
                      response = await client.TheServiceFunction().ConfigureAwait(false);
                      ((ICommunicationObject)client).Close();
                 }
                 catch
                 {
                      if (client != null)
                      {
                           ((ICommunicationObject)client).Abort();
                           return new result ( failure = true);
                      }
                 }
            }
            if (response != null)
            {
                     //Whatever you want to do with the response here
                     return new result ( failure = false);
            }
    }
