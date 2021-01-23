    using xUnit;
    
    [Fact]
    public async Task LoginThrowsAsExpectedTest()
    {   
        // Arrange     
        var controller = new LoginController();
        var loggerMock = new Mock<ILogger>();
        var authModuleMock = new Mock<IAuthenticationModule>();
        
        var expectedMessage = "I knew it!";       
 
        // Setup async methods! 
        authModuleMock.Setup(am => am.ExternalAuthenticateAsync(It.IsAny<CredentialsModel>())
                      .ThrowsAsync(new Exception(expectedMessage));
        // Act
        var result = 
            await controller.Login(
                new CredentialsModel(),
                loggerMock.Object,
                authModuleMock.Object,
                null);
       
        
        // Assert
        Assert.Equal(expectedMessage, result.FailureMsg);
    }
