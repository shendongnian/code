    Mock<HttpSessionStateBase> _mockSession = new Mock<HttpSessionStateBase>();
    Mock<HttpContextBase> _mockHttpContext = new Mock<HttpContextBase>();
    _mockSession.Setup(x => x["windowsUserName"]).Returns("Joe Cool");
    _mockHttpContext.SetupGet(ctx => ctx.Session).Returns(_mockSession.Object);
    Assert.AreEqual("Joe Cool", _mockHttpContext.Object.Session["windowsUserName"]);
