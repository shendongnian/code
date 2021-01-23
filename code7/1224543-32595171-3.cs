    public void Test() {
        // Arrange
        var logger = new ListLogger();
        var cut = CreateValidClassUnderTest(logger);
        // Act
        cut.DoSomething();
        
        // Arrange
        Assert.IsTrue(logger.Count > 0);    
    }
