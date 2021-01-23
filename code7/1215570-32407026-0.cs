    [Test]
    public void TestMethod()
    {
        // Arrange
        var apiMock = new Mock<IFooApi>();
        apiMock.Setup(api => api.Post(It.IsAny<MyModel>())).ReturnsAsync(new OkNegotiatedContentResult<Result>(new Result(), new FooApi()));
        // Act
        var testObject = new FooController(apiMock.Object);
        var viewResult = testObject.Post(new MyViewModel()).Result as ViewResult;
        var result = (Result)viewResult.Model;
        // Assert
        Assert.AreEqual(2, result.Product);
    }
