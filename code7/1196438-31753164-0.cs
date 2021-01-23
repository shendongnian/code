    var controller = new UserController();
    var mock = new Mock<ControllerContext>();
    mock.SetupGet(x => x.HttpContext.User.Identity.Name).Returns("SOMEUSER");
    mock.SetupGet(x => x.HttpContext.Request.IsAuthenticated).Returns(true);
    controller.ControllerContext = mock.Object;
