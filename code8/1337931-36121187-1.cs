    // Arrange
    RouteCollection routes = new RouteCollection();
    // you can map attribute routes
    routes.MapMvcAttributeRoutes();
    // and/or add routes manually
    routes.MapRoute(
            name: "Default",                                                 // Route name 
            url: "{controller}/{action}/{id}",                               // URL with parameters 
            default: new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
    );
    moqRequest.Setup(e => e.AppRelativeCurrentExecutionFilePath).Returns("~/Home/Index");
    // Act
    RouteData routeData = routes.GetRouteData(moqContext.Object);
    // Assert
    Assert.IsNotNull(routeData);
    Assert.AreEqual("Home", routeData.Values["controller"]);
    Assert.AreEqual("Index", routeData.Values["action"]);
