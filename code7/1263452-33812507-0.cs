    [Theory, AutoMoqData]
    public void Test(
        [Frozen]Mock<ISomeWebservices> mock,
        MyWebServiceClass sut,
        object someData,
        object response)
    {
        mock.Setup(foo => foo.SomeRequest(someData)).Returns(@"{""user"": ""12345"",""somedata"": ""60"",""someotherdata"":""2015-09-01T12:00:00.200Z""}");
        sut.SomeRequest(someData, s => response = s);
        // Assertions go here...
    }
