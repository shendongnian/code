    namespace UnitTestProject3
    {
        public class UnitTest1
        {
            IWebDriver wb;
            String url = "http://www.yahoo.com";
            [Fact]
            public void TestMethod1()
            {
                wb = new ChromeDriver();
                wb.Navigate().GoToUrl(url);
            }
        }
    }
