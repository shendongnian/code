    private void SendAliveMessage()
    {
        const string keepAliveMessage = "{\"message\": {\"type\": \"keepalive\"}}";
        var sreamWriter = new StreamWriter(_webRequest.GetRequestStream());
        while (IsRunning)
        {
            sreamWriter.WriteLine(keepAliveMessage);
            Thread.Sleep(10 * 1000);
        }    
    }
