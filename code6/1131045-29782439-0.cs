    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(ChromeDriver))]
    public class CustomerLogin<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        private IWebDriver driver;
        private string url;
        [SetUp]
        public void SetUp()
        {
            this.driver = new TWebDriver();
            url = System.Configuration.ConfigurationManager.AppSettings["homeUrl"];
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            //Finding the customer login link and clicking it
            driver.FindElement(By.Id("Homepage_r2_c14")).Click();
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
