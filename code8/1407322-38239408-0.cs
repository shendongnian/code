    [OperationBehavior(TransactionScopeRequired = true)]
    public async Task GetData(int start, int end)
    {
        try
        {
            await Task.Factory.StartNew(() =>
            {
                using (WebServiceReference.Service1Client webClient = new WebServiceReference.Service1Client())
                {
                     Task<string> data = GetWebClientData(start, webClient);
                     MSMQ.Utils.LoggerHelper.GetLogger().InfoFormat("Received info from web service. Data\t{0}", data.Result);
                }
            }
      }
      catch (Exception e)
      {
          MSMQ.Utils.LoggerHelper.GetLogger().ErrorFormat("{1}\r\n{0}", e.Message, e.GetType().FullName);
         throw;
      }
    }
    private static async Task<string> GetWebClientData(int start, WebServiceReference.Service1Client webClient)
    {
        return await webClient.GetDataAsync(start);
    }
