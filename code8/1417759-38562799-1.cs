    [TestMethod,Isolated]
    public void AllBMethodReturnStrings_WillReturnSuccess()
    {
        // Arrange
        // Mocking future B's instance
        var fakeIB = Isolate.Fake.NextInstance<B>();
        var realA = new A();
    
        Isolate.WhenCalled(()=> fakeIB.GetId()).WillReturn("fakeID");
        Isolate.WhenCalled(() => fakeIB.GetKey()).WillReturn("fakeKey");
        Isolate.WhenCalled(() => fakeIB.GetToken()).WillReturn("success");
    
        // Act
        var result = realA.functionA();
    
        // Assert
        Assert.AreEqual("success", result);
    }
