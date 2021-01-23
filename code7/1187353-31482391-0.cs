    [TestInitialize]
    public void Initialize()
    {
        _callApi = new Mock<ICallApi>();
        _gpiRepository = new GpiRepository(_callApi.Object);
       //initialize your server
       //set _gpiRepository as a dependency and etc..
    }
    [TestMethod]
    public void EleveController__GroupeRepere_WithBadFiche_400BadRequest()
    {
        //configure the request
        var result = client.ExecuteAsGet<GroupeRepere>(<your request>);
        Assert.AreEqual(HttpStatusCode.BadRequest,result.StatusCode);
    }
