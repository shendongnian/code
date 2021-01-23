    [TestMethod, Isolated]
    public void TestMethodWasCalled()
    {
        //Arrange
        var fakeWebApi = Isolate.Fake.AllInstances<WebApiClass>(Members.CallOriginal);
        Isolate.WhenCalled(() => fakeWebApi.WebApiCall()).IgnoreCall();
    
        //Act
        FunctionalClass target = new FunctionalClass();
        target.function1();
    
        //Assert
        Isolate.Verify.WasCalledWithAnyArguments(() => fakeWebApi.WebApiCall());
    }
