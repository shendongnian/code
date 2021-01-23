    var myController = new MyController([mocked dependencies here]);
    myController.ControllerContext = mockedControllerContext;
    var result = myController.MyActionWhichReturnsAViewResult();
    Assert.IsNotNull(result);
    Assert.IsInstanceOf<ViewResult>(result);
    Assert.That(result.ViewName == [expectedViewName])
