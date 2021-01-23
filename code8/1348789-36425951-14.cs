    private IHttpClient _httpClient;
    
    [TestMethod]
    public void TestMockConnection()
    {
        SomeModelObject model = new SomeModelObject();
        var httpClientMock = new Mock<IHttpClient>();
        httpClientMock.Setup(c => c.GetAsync<SomeModelObject>(It.IsAny<string>()))
            .Returns(() => Task.FromResult(model));
    
        var client = new Connection(httpClientMock.Object);
    
        //Assuming doSomething uses the client to make a call to get a model of type SomeModelObject
        client.doSomething();  
    }
