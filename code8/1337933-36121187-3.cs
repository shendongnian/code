    // Arrange
    RouteCollection routes = new RouteCollection();
    // add routes
    routes.MapRoute(
            name: "Default",                                                 // Route name 
            template: "{controller}/{action}/{id}",                          // template with parameters 
            default: new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
    );
    moqRequest.Setup(e => e.AppRelativeCurrentExecutionFilePath).Returns("~/Home/Index");
    // Act
    RouteData routeData = routes.GetRouteData(moqContext.Object);
    // Assert
    Assert.IsNotNull(routeData);
    Assert.AreEqual("Home", routeData.Values["controller"]);
    Assert.AreEqual("Index", routeData.Values["action"]);
