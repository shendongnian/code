    var connection = new HubConnection("http://localhost:65069/");
    IHubProxy proxy = connection.CreateHubProxy("stockTickerMini");
    try
    {
        connection.Start().Wait();
        var stocks = proxy.Invoke<IEnumerable<Stock>>("GetAllStocks").Result;
    }
    ...
