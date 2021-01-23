    public abstract class ViewTest : WebTest
    {
        private RemoteWebDriver _driver;
        protected ViewTest()
        {
            Driver = SeleniumManager.CreateDriver();
        }
        public RemoteWebDriver Driver
        {
            get { return _driver; }
            set
            {
                var attribute = GetType().GetCustomAttribute<OnlySupportsBrowsersAttribute>();
                if (attribute != null && !attribute.Browsers.Any(x => x == TestRunSettings.BrowserToUse))
                {
                    Assert.Inconclusive($"Browser {TestRunSettings.BrowserToUse} is not supported by this test");
                }
                _driver = value;
            }
        }
    }
