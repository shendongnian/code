    [TestMethod]
    public void Func_Should_Be_Invoked_Once() {
        //Arrange
        var handlers = new List<ICallBridgeHandler>();
        var stationIdReader = new Mock<IStationIdReader>();
        var mockLogger = new Mock<ILogger>();
        int loggerCreaterInvokeCalls = 0;
        Func<Type, ILogger> loggerCreator = (type) => {
            loggerCreaterInvokeCalls++;
            return mockLogger.Object;
        };
        //Act
        var sut = new Service(stationIdReader.Object, handlers, loggerCreator);
        //Assert
        Assert.IsNotNull(sut);
        Assert.AreEqual(1, loggerCreaterInvokeCalls);
    }
