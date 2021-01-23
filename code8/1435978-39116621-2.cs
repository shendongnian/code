    [Test]
    public async Task CreateDemo_returns_BadRequestErrorMessageResult_when_request_is_null()
    {
       // Arrange
       var controller = new HomeController();
       // Act
       var response = await controller.CreateDemo(null);
       // Assert
       Assert.IsInstanceOf<BadRequestErrorMessageResult>(response);
       Assert.AreEqual("request can not be null", response.Message);
    }
    [Test]
    public async Task CreateDemo_returns_BadRequestErrorMessageResult_when_request_ID_is_empty_GUID()
    {
       // Arrange
       var controller = new HomeController();
       var request = new MyRequest(Guid.Empty);
       // Act
       var response = await controller.CreateDemo(request);
       // Assert
       Assert.IsInstanceOf<BadRequestErrorMessageResult>(response);
       Assert.AreEqual("MyID must be provided", response.Message);
    }
