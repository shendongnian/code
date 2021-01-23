    [TestMethod]
    public void Test_MyMethod()
    {
        var mock = new Mock<ILogger>();
    
        mock.Setup(y => y.Log(It.IsAny<string>()).Verifiable();
    
        var o = new MyClass(mock.Object);
    
        var result = o.MyMethod(5);
    
        Assert.IsTrue(result);        
    
        mock.Verify();
    
    }
