    [TestMethod, Isolated]
    public void TestIgnoreD()
    {
        //Arrange
        Methods methods = new Methods();
        Isolate.WhenCalled(() => methods.D(0)).IgnoreCall();
    
        //Act
        bool result = methods.A(1);
    
        //Assert
        Assert.IsTrue(result);
    }
