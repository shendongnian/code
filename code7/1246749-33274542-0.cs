    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using OpenQA.Selenium.Chrome;
    
    namespace UnitTestProject1
    {
        [TestClass]
        public class BrowserTest
        {
        string DRIVER_PATH = @"C:...misc...\Selenium Webdriver\chromedriver";
    
            [TestMethod]
            public void ChromeTest()
            {
                IWebDriver driver = new ChromeDriver(DRIVER_PATH);
                driver.Navigate().GoToUrl("http://www.google.com");
            }
        }
    }
