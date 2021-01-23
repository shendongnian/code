    public void SomeAction_ReturnsOk()
    {
        //Arrange
        var logger = Substitute.For<ILogger>();
        logger.ForContext(Arg.Any<string>()).Returns(logger);
        var controller = new SomeController(logger) {
            Request = Substitute.For<HttpRequestMessage>()
        };
    
        //Act
        var result = controller.SomeAction();
    
        //Assert
        logger.Received().Information(Arg.Any<string>());
    }
