    [TestMethod, Isolated]
    public void TestIndexerFake()
    {
        //Arrange
        var MyClassFake = Isolate.Fake.AllInstances<MyClass>(Members.CallOriginal);
        Isolate.WhenCalled(() => MyClassFake["test"]).WillReturn("fake!");
    
        //Act
        MyClass target = new MyClass();
        var result = target.returnString("test");
    
        //Assert
        Assert.AreEqual("fake!", result);
    }
