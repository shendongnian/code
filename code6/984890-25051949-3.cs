    MyCustomObject externalObj;
    private static async Task CheckNetworkFileAsync()
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
