    public class Page
    {
        private IWebDriver driver;
        [FindsBy(How = How.Id, Using = "content")]
        public IWebElement ele;
        public Page(IWebDriver _driver)
        {
            this.driver = _driver;
        }
    }
