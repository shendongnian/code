    [TestMethod]
    public void TestLogging()
    {
        //Arrange
        Isolate.WhenCalled(() => myLogger.ErrorLogging("")).CallOriginal();
    
        //Act
        var foo = new myClassthatDoesStuff();
        foo.DoStuff();
    
        //Assert
        Isolate.Verify.WasCalledWithAnyArguments(() => myLogger.ErrorLogging(""));
    }
