    [Test]
    async public void Test()
    {
      // create and use an HttpClient here, doing POSTs, PUTs, and GETs
    }
    
    // Notice the removal of the async keyword since now using Wait() in method body
    [TearDown]
    public void TerminateSession()
    {
      // create and use an HttpClient here and use Wait().
      httpClient.SendAsync(httpRequestMessage).Wait();
    }
