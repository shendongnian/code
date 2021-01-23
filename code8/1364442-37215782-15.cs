	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using MvcRouteTesting;
	using System.Web;
	using System.Web.Mvc;
	using System.Web.Routing;
	[TestClass]
	public class OutgoingRouteTests
	{
		[TestMethod]
		public void ActionWithAmbientControllerSpecificAction()
		{
			UrlHelper helper = GetUrlHelper();
			string url = helper.Action("action");
			Assert.AreEqual("/defaultcontroller/action", url);
		}
		[TestMethod]
		public void ActionWithSpecificControllerAndAction()
		{
			UrlHelper helper = GetUrlHelper();
			string url = helper.Action("action", "controller");
			Assert.AreEqual("/controller/action", url);
		}
		[TestMethod]
		public void ActionWithSpecificControllerActionAndId()
		{
			UrlHelper helper = GetUrlHelper();
			string url = helper.Action("action", "controller", new { id = 42 });
			Assert.AreEqual("/controller/action/42", url);
		}
		[TestMethod]
		public void RouteUrlWithAmbientValues()
		{
			UrlHelper helper = GetUrlHelper();
			string url = helper.RouteUrl(new { });
			Assert.AreEqual("/defaultcontroller/defaultaction", url);
		}
		[TestMethod]
		public void RouteUrlWithAmbientValuesInSubApplication()
		{
			UrlHelper helper = GetUrlHelper(appPath: "/subapp");
			string url = helper.RouteUrl(new { });
			Assert.AreEqual("/subapp/defaultcontroller/defaultaction", url);
		}
		[TestMethod]
		public void RouteUrlWithNewValuesOverridesAmbientValues()
		{
			UrlHelper helper = GetUrlHelper();
			string url = helper.RouteUrl(new
			{
				controller = "controller",
				action = "action"
			});
			Assert.AreEqual("/controller/action", url);
		}
		static UrlHelper GetUrlHelper(string appPath = "/", RouteCollection routes = null)
		{
			if (routes == null)
			{
				routes = new RouteCollection();
				RouteConfig.RegisterRoutes(routes);
			}
			HttpContextBase httpContext = new StubHttpContextForRouting(appPath);
			RouteData routeData = new RouteData();
			routeData.Values.Add("controller", "defaultcontroller");
			routeData.Values.Add("action", "defaultaction");
			RequestContext requestContext = new RequestContext(httpContext, routeData);
			UrlHelper helper = new UrlHelper(requestContext, routes);
			return helper;
		}
	}
