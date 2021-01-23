    MyCustomObject externalObj;  // my custom object
    private static async Yask CheckNetworkFile()
    {
        try
        {
            WebClient webClient = new WebClient();
            
            Stream stream = await webClient.OpenReadTaskAsync(new Uri("http://externalURl.com/sample.xml", UriKind.Absolute));                
            externalObj = myReadWebclientResponse(stream);
        }
        catch (Exception)
        {
          externalObj=null;
        }
    }
