	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using MvcRouteTesting;
	using System.Web.Mvc;
	using System.Web.Routing;
	[TestClass]
	public class IncomingRouteTests
	{
		[TestMethod]
		public void RouteWithControllerNoActionNoId()
		{
			// Arrange
			var context = new StubHttpContextForRouting(requestUrl: "~/controller1");
			var routes = new RouteCollection();
			RouteConfig.RegisterRoutes(routes);
			// Act
			RouteData routeData = routes.GetRouteData(context);
			// Assert
			Assert.IsNotNull(routeData);
			Assert.AreEqual("controller1", routeData.Values["controller"]);
			Assert.AreEqual("Index", routeData.Values["action"]);
			Assert.AreEqual(UrlParameter.Optional, routeData.Values["id"]);
		}
		[TestMethod]
		public void RouteWithControllerWithActionNoId()
		{
			// Arrange
			var context = new StubHttpContextForRouting(requestUrl: "~/controller1/action2");
			var routes = new RouteCollection();
			RouteConfig.RegisterRoutes(routes);
			// Act
			RouteData routeData = routes.GetRouteData(context);
			// Assert
			Assert.IsNotNull(routeData);
			Assert.AreEqual("controller1", routeData.Values["controller"]);
			Assert.AreEqual("action2", routeData.Values["action"]);
			Assert.AreEqual(UrlParameter.Optional, routeData.Values["id"]);
		}
		[TestMethod]
		public void RouteWithControllerWithActionWithId()
		{
			// Arrange
			var context = new StubHttpContextForRouting(requestUrl: "~/controller1/action2/id3");
			var routes = new RouteCollection();
			RouteConfig.RegisterRoutes(routes);
			// Act
			RouteData routeData = routes.GetRouteData(context);
			// Assert
			Assert.IsNotNull(routeData);
			Assert.AreEqual("controller1", routeData.Values["controller"]);
			Assert.AreEqual("action2", routeData.Values["action"]);
			Assert.AreEqual("id3", routeData.Values["id"]);
		}
		[TestMethod]
		public void RouteWithTooManySegments()
		{
			// Arrange
			var context = new StubHttpContextForRouting(requestUrl: "~/a/b/c/d");
			var routes = new RouteCollection();
			RouteConfig.RegisterRoutes(routes);
			// Act
			RouteData routeData = routes.GetRouteData(context);
			// Assert
			Assert.IsNull(routeData);
		}
		[TestMethod]
		public void RouteForEmbeddedResource()
		{
			// Arrange
			var context = new StubHttpContextForRouting(requestUrl: "~/foo.axd/bar/baz/biff");
			var routes = new RouteCollection();
			RouteConfig.RegisterRoutes(routes);
			// Act
			RouteData routeData = routes.GetRouteData(context);
			// Assert
			Assert.IsNotNull(routeData);
			Assert.IsInstanceOfType(routeData.RouteHandler, typeof(StopRoutingHandler));
		}
	}
