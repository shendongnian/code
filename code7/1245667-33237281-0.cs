    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Chrome;
    using NUnit;
    using OpenQA.Selenium.Remote;
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
            ICapabilities capabilities = ((RemoteWebDriver)_driver).Capabilities;
            string browser = capabilities.BrowserName;
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("http://www.google.ie/");
            if (browser == "internet explorer")
            {
                _driver.FindElement(By.Id("lst-ib")).SendKeys("MongoDB");
            }
            else if (browser == "chrome")
            {
                _driver.FindElement(By.Id("lst-ib")).SendKeys("ElasticSearch");
            }
            else 
            {
                _driver.FindElement(By.Id("lst-ib")).SendKeys("Selenium");
            }
            _driver.FindElement(By.Name("btnG")).Click(); 
            FixtureTearDown();
        }
        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            _driver.Close();
        }
    }
    }
