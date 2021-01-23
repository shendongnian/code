    [TestMethod]
    public void RunAction_WhenActionThrowsException_LoggerIsInvoked()
    {
    	// Arrange
    	var badException = new Exception("I'm bad");
    	var loggerMock = new Mock<ILogger>();
    	var instance = new ExceptionHandler(loggerMock.Object);
    	var badMethod = () => throw badException;
    	
    	// Act
    	instance.RunAction(badMethod);
    	
    	// Assert
    	loggerMock.Verify(logger => logger.LogException(badException), Times.Once());
    }
