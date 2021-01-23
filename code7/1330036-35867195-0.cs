    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    
    namespace ConsoleApplication1
    {
        public static class SeleniumTest
        {
            public static void Main(string[] args)
            {
                IWebDriver driver = new FirefoxDriver();
                driver.Navigate().GoToUrl("http://www.bing.com/");
                driver.Manage().Window.Maximize();
    
                IWebElement searchInput = driver.FindElement(By.Id("sb_form_q"));
                searchInput.SendKeys("Hello World");
                searchInput.SendKeys(Keys.Enter);
    
                searchInput = driver.FindElement(By.Id("sb_form_q"));
                string actualvalue = searchInput.GetAttribute("value");
    
                Assert.AreEqual(actualvalue, "Hello World");
                driver.Close();
            }
        }
    }
