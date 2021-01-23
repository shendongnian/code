    [TestMethod, Isolated]
    public void WhenPassedControllerAndActionMatchContextReturnSelectedClass()
    {
        var fakeHtmlHalper = Isolate.Fake.Dependencies<HtmlHelper>();
        var fakeViewContext = Isolate.GetFake<ViewContext>(fakeHtmlHalper);
    
        Isolate.WhenCalled(() => fakeViewContext.RouteData.Values["controller"]).WillReturn("performance");
        Isolate.WhenCalled(() => fakeViewContext.RouteData.Values["action"]).WillReturn("search");
    
        var result = fakeHtmlHalper.IsSelected("performance", "search");
    
        Assert.AreEqual("selected", result);
    
    }
