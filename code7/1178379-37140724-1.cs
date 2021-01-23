    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver _driver = new FirefoxDriver();
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 1, 0));
            _driver.Navigate().GoToUrl(@"file:///C:/Users/Kishore/Desktop/alert.html");
            _driver.FindElement(By.Id("btnAlert")).Click();
            _driver.SwitchTo().Alert().Accept();
            string output = _driver.FindElement(By.Id("output")).Text;
            Assert.AreEqual("Alert is gone.", output);
            _driver.FindElement(By.Id("btnPrompt")).Click();
            _driver.SwitchTo().Alert().SendKeys("Web Driver");
            _driver.SwitchTo().Alert().Accept();
            output = _driver.FindElement(By.Id("output")).Text;
            Assert.AreEqual("Web Driver", output);
            _driver.Close();
        }
    }
