    [TestMethod]
    public void AdminRouteUrlIsRoutedToHomeAndIndex()
    {
        var routes = new RouteCollection();
        var areaRegistration = new AdminAreaRegistration();
        Assert.AreEqual("Admin", areaRegistration.AreaName);
        var areaRegistrationContext = new AreaRegistrationContext(areaRegistration.AreaName, routes);
        areaRegistration.RegisterArea(areaRegistrationContext);
        routes.ShouldMap("/admin").To<HomeController>(r => r.Index());
    }
