    SPWebService ws = SPWebService.ContentService;
    SPClientRequestServiceSettings clientSettings = ws.ClientRequestServiceSettings;
    clientSettings.MaxReceivedMessageSize = 10485760;
    ws.Update();
    Console.WriteLine(clientSettings.MaxReceivedMessageSize);
