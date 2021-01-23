    [Fact]
    public void CreateSessionVariableTest()
    {
        var sessionMock = new Mock<ISession>();
        sessionMock.Setup(s => s.Get("MyVar")).Returns("Hi);
        
        var classToTest = new ClassToTest(sessionMock.Object);
        classToTest.CreateSessionVariable();
    }
