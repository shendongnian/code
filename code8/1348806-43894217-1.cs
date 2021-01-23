    [TestMethod]
    public void TestMethod1()
    {
        // Arrange
        var mockMessageHandler = new Mock<HttpMessageHandler>();
        // Set up your mock behavior here
        var auroraClient = new AuroraClient(mockMessageHandler.Object);
        // Act
        // Assert
    }
