    public class BeforeAllTests
    {
        private readonly IObjectContainer objectContainer;
        private static SeleniumContext seleniumContext;
    
        public BeforeAllTests(IObjectContainer container)
        {
            this.objectContainer = container;
        }
    
        [BeforeTestRun]
        public static void RunBeforeAllTests()
        {
            seleniumContext = new SeleniumContext();
        }
    
        [BeforeScenario]
        public void RunBeforeScenario()
        {
            objectContainer.RegisterInstanceAs<SeleniumContext>(seleniumContext);
            seleniumContext.driver.Navigate().GoToUrl("http://localhost:8080");
        }
    }
