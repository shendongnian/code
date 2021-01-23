    [TestFixture(typeof(FirefoxDriver))]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    public class UnitTest1<TWebDriver> where TWebDriver: IWebDriver, new()
    {
        // ...
        public IEnumerable<string> UrlsToTest
        {
            get
            {
                yield return "http://www.example.com/1";
                yield return "http://www.example.com/2";
                yield return "http://www.example.com/3";
            }
        }
        [TestCaseSource("UrlsToTest")]
        public void Test1(string url)
        {
            // ...
        }
        [TestCaseSource("UrlsToTest")]
        public void Test2(string url)
        {
            // ...
        }
    }
