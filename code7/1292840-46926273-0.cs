    public static class HttpContextExtensions
    {
        public static void MockHttpContext(this Controller controller)
        {
            var httpContextMock = new Mock<HttpContextBase>();
            var requestMock = new Mock<HttpRequestBase>();
            var responseMock = new Mock<HttpResponseBase>();
            responseMock.SetupAllProperties();
            requestMock.SetupAllProperties();
            httpContextMock.Setup(x => x.Response).Returns(responseMock.Object);
            httpContextMock.Setup(x => x.Request).Returns(requestMock.Object);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = httpContextMock.Object;
        }
    }
