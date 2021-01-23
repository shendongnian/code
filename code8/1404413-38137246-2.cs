    try
    {
        var hubConnection = new HubConnection(url,...); 
        ... ; /*defining proxies and handlers*/
        hubConnection.Start().Wait();
    } 
    catch(Exception ex)
    { 
       /*handle exception code */
    }
