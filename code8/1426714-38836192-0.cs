    public async Task<IHttpActionResult> Get()
    {
        Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager
            .GetHubContext<Hubs.ConfigHub>()
            .Clients.Client("SomeConnectionId")
            .PleaseSendYourDataToTheHub();
        
         // don´t return anything and don´t await for results on the web client
     }
