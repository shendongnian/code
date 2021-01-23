    [TestMethod]
    public void DeleteFilter_ExceptionThrown_IsCaughtAndLoggedAndReturnsActionResultOfError() {
        // Arrange
        var serviceFactoryMock = new Mock<IServiceFactory>();
        serviceFactoryMock
            .Setup(x => x.GetService(It.IsAny<string>())
            .Throws(new Exception())
            .Verifiable();
        var controller = new MyController(serviceFactoryMock.Object);
        // Act
        var result = controller.DeleteFilter("blah blah");
        //Assert
        serviceFactoryMock.Verify(); // verifies that the setup was invoked
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result, typeof(JsonActionResult));
        //...other assertions
    }
