    using (var client = new WebClient())
    {
        var data = GetSoap();
        client.Headers.Add("Content-Type", "text/xml;charset=utf-8");
        client.Headers.Add("SOAPAction", "\"http://tempuri.org/ICollection/GetAllCollections\"");
        var response = client.UploadString("http://localhost:50436/FabSvc.svc", data);
        Console.WriteLine(response);
    }
