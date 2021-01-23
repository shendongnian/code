    var controllerContext = new Mock<ControllerContext>();
    var principal = new Moq.Mock<IPrincipal>();
    principal.Setup(p => p.IsInRole("Administrator")).Returns(true);
    principal.SetupGet(x => x.Identity.Name).Returns(userName);
    controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal.Object);
    controller.ControllerContext = controllerContext.Object;
