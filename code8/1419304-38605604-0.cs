    var owinMock = new Mock<IOwinContext>();
    owinMock.Setup(o => o.Authentication.User).Returns(new ClaimsPrincipal());
    owinMock.Setup(o => o.Environment).Returns(new Dictionary<string, object> { {"key1", 123} });
    var traceMock = new Mock<TextWriter>();
    owinMock.Setup(o => o.TraceOutput).Returns(traceMock.Object);
