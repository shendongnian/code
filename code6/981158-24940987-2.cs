    [TestFixture]
    class GoogleTestsChrome
    {
        [Test]
        public void GoogleTest()
        {
             try
             {
                  FixtureSetup();
                  _driver.Navigate().GoToUrl(url);
                  Assert.AreEqual("Google", _driver.Title);
             }
             finally
             {
                  _driver.Quit();
             }
        }
    }
