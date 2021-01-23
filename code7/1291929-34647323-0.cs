    [TestFixture]
    public class TestClass
    {
        private FirefoxDriver _driver;
    
        [SetUp]
        public void Setup()
        {
            _driver = new FirefoxDriver();
            _driver.Url = "http://motherboard.vice.com/read/i-built-a-botnet-that-could-destroy-spotify-with-fake-listens";
        }
    
        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    
        [TestCase()]
        public void TestImage()
        {
            IWebElement element = _driver.FindElementByXPath("//img[@class = 'vmp-image' and position() = 1]");
    
            Assert.IsNotNull(element);
    
            string width = element.GetCssValue("width");
            string height = element.GetCssValue("height");
    
            Console.WriteLine("width:  " + width);
            Console.WriteLine("height: " + height);
        }
    }
