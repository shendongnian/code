    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Chrome;
    namespace MultipleBrowserTesting
    {
    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    public class BlogTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver _driver;
        [Test]
        public void Can_Visit_Google()
        {
            _driver = new TWebDriver();
            // Navigate
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://www.google.com/");
        }
        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            if (_driver != null) 
                _driver.Close();
        }
    }
    }
