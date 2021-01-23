    [Test]
    public void Search_Get_ReturnsViewResult()
    {
      // arrange
      IPathProvider mockedPathProvider = //...insert your mock/fake/stub here
      var performanceController = PerformanceControllerInstance(mockedPathProvider);
      // act
      var result = performanceController.Search();
      //assert
      Assert.IsNotNull(result as ViewResult);
    }
