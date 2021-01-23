    public class GetModelExtententionsTests
    {
        private readonly Browser _browser;
        public GetModelExtententionsTests()
        {
            this._browser = new Browser(with => {
               with.Module<AModuleToTestExtensionMethodsWith>();
               with.ViewFactory<TestingViewFactory>();
            });
        }
    
        [Fact]
        public void Can_get_the_model_and_read_the_values()
        {
           var response = this._browser.Get("/testingViewFactory");
           var model = response.GetModel<ViewFactoryTestModel>();
           Assert.Equal("A value", model.AString);
        }
    }
