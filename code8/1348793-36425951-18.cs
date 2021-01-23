    private IHttpClient _httpClient;
    
    [TestMethod]
    public void TestMockConnection()
    {
        SomeModelObject model = new SomeModelObject();
        var httpClientMock = new Mock<IHttpClient>();
        httpClientMock.Setup(c => c.GetAsync<SomeModelObject>(It.IsAny<string>()))
            .Returns(() => Task.FromResult(model));
    
        _httpClient = httpClientMock.Object;
        var client = new Connection(_httpClient);
    
        // Assuming doSomething uses the client to make
        // a request for a model of type SomeModelObject
        client.doSomething();  
    }
