    protected HtmlHelper<T> CreateHtmlHelper<T>(T instance)
    {
        var viewDataDictionary = new ViewDataDictionary<T>(instance);
        var viewContext = A.Fake<ViewContext>();
        A.CallTo(() => viewContext.ViewData).Returns(viewDataDictionary);
        var viewDataContainer = A.Fake<IViewDataContainer>();
        A.CallTo(() => viewDataContainer.ViewData).Returns(viewDataDictionary);
        return new HtmlHelper<T>(viewContext, viewDataContainer);
    }
