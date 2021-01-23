    public static class MvcHelper
    {
        public static HtmlHelper<TModel> GetHtmlHelper<TModel>(TModel inputDictionary)
        {
            var viewData = new ViewDataDictionary<TModel>(inputDictionary);
            var mockViewContext = new Mock<ViewContext> { CallBase = true };
            mockViewContext.Setup(c => c.ViewData).Returns(viewData);
            mockViewContext.Setup(c => c.HttpContext.Items).Returns(new Hashtable());
            return new HtmlHelper<TModel>(mockViewContext.Object, GetViewDataContainer(viewData));
        }
        public static IViewDataContainer GetViewDataContainer(ViewDataDictionary viewData)
        {
            var mockContainer = new Mock<IViewDataContainer>();
            mockContainer.Setup(c => c.ViewData).Returns(viewData);
            return mockContainer.Object;
        }
    }
