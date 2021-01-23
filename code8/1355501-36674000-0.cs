    [TestMethod, Isolated]
    public void TestFakeArgs()
    {
        //Arrange
        Isolate.WhenCalled(() => Environment.GetCommandLineArgs()).WillReturn(new[] { "Your", "Fake", "Args" });
    
        //Act
        string[] args = Environment.GetCommandLineArgs();
    
        //Assert
        Assert.AreEqual("Your", args[0]);
        Assert.AreEqual("Fake", args[0]);
        Assert.AreEqual("Args", args[0]);
    }
