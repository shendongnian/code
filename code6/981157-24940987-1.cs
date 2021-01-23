    [TestFixture]
    class GoogleTestsChrome
    {
        [Test]
        public void GoogleTest()
        {
             try
             {
                  IWebDriver webDriver = FixtureSetup();
                  webDriver.Navigate().GoToUrl(url);
                  Assert.AreEqual("Google", webDriver.Title);
             }
             finally
             {
                  webDriver.Quit();
             }
        }
    }
