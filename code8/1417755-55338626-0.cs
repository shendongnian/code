    var identity = new Mock<IIdentity>();
    identity.SetupGet(i => i.IsAuthenticated).Returns(true);
    identity.SetupGet(i => i.Name).Returns("FakeUserName");
    var mockPrincipal = new Mock<ClaimsPrincipal>();
    mockPrincipal.Setup(x => x.Identity).Returns(identity.Object);
    var mockAuthHandler = new Mock<ICustomAuthorizationHandler>();
    mockAuthHandler.Setup(x => x.CustomAuth(It.IsAny<ClaimsPrincipal>(), ...)).Returns(true).Verifiable();
                    
    var controller = new MyController(...);
    var mockHttpContext = new Mock<HttpContext>();
    mockHttpContext.Setup(m => m.User).Returns(mockPrincipal.Object);
    controller.ControllerContext = new ControllerContext();
    controller.ControllerContext.HttpContext = new DefaultHttpContext()
    {
        User = mockPrincipal.Object
    };
    var result = controller.Get() as OkObjectResult;
    //Assert results
    mockAuthHandler.Verify();
