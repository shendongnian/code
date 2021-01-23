	[TestMethod]
	public void MyTestMethod()
	{
		// Arrange
		RouteData fakeRouteData = new RouteData();
		ViewContext fakeViewContext = new ViewContext();
		fakeRouteData.DataTokens["ParentActionViewContext"] = fakeViewContext;
		Mock<HttpContextBase>  httpContextStub = new Mock<HttpContextBase>();
		RequestContext requestContext = new RequestContext(httpContextStub.Object, fakeRouteData);
		HomeController controller = new HomeController();
		var mockControllerContext = new Mock<ControllerContext>(requestContext, controller) { CallBase = true, };
		mockControllerContext.SetupGet(m => m.IsChildAction).Returns(true);
		
		controller.ControllerContext = mockControllerContext.Object;
		// Act
		var res = controller.Update();
		// Assert
		// TODO ...
	}
