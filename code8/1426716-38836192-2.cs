    public async Task<IHttpActionResult> Get()
    {
        Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager
            .GetHubContext<Hubs.ConfigHub>()
            .Clients.Client("SomeConnectionId")
            .PleaseSendYourDataToTheHub();
        
         // don´t return anything and don´t await for results on the web client. 
         // The client just needs a 200 (ok) response to be sure the request 
         // is sent and going on.
     }
