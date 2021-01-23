    public Client()
    {
        _webRequest = WebRequest.Create("some url");
        _webRequest.Method = "POST";
    
        IsRunning = true;
    
        SendAliveMessageAsync();    //just call it and forget it.
    }
