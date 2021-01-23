    using xUnit;
    
    [Fact]
    public async Task LoginHandlesIsNotAuthenticatedTest()
    {   
        // Arrange     
        var controller = new LoginController();
        var loggerMock = new Mock<ILogger>();
        var authModuleMock = new Mock<IAuthenticationModule>();        
        var expectedMessage = "Invalid credentials."; 
        // Setup async methods! 
        authModuleMock.Setup(am => am.ExternalAuthenticateAsync(It.IsAny<CredentialsModel>())
                      .ReturnsAsync(new AuthResult { IsAuthenticated = false });        
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
