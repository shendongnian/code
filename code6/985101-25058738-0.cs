    [TestFixture]
    class UnitTests
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitlyWait(Defaultamount);
            _wait = new WebDriverWait(_driver, Defaultamount);
        }
        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            _driver.Quit();
        }
        //...
    }
