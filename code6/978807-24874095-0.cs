    Task ConsumeService()
    {
        var myScheduler = new myScheduler();
        var myFactory = new Factory(myScheduler); 
        var client = new ClientProxy(); 
        
        return Task.WhenAll(Requests.Select(request => myFactory.StartNew(
            () =>
            {
                client.GetResponsesAsync(request);
            }).Unwrap()
            ));
    }
