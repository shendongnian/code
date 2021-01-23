    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Support.UI;
    
    namespace ExampleUITest
    {
        [TestClass]
        public class ExampleUITest
        {
            private IWebDriver driver;
            private string serverPath = "Microsoft Web Driver";
            private string baseUrl = "http://example.com";
    
    
            [TestInitialize]
            public void TestInitialize()
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    serverPath = Path.Combine(Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%"), serverPath);
                }
                else
                {
                    serverPath = Path.Combine(Environment.ExpandEnvironmentVariables("%ProgramFiles%"), serverPath);
                }
                var options = new EdgeOptions
                {
                    PageLoadStrategy = EdgePageLoadStrategy.Eager
                };
                driver = new EdgeDriver(serverPath, options);
                driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(5));
            }
    
            [TestCleanup]
            public void TestFinalize()
            {
                // Automatically closes window after test is run
                driver?.Close();
            }
    
            [TestMethod]
            public void LoadHomePage()
            {
                driver.Url = baseUrl;
    
                var element = driver.FindElement(By.LinkText("Example Link Text"));
                element.Click();
    
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                wait.Until(w => w.Url == $"{baseUrl}/ExampleLink");
                Assert.AreEqual(driver.Url, $"{baseUrl}/ExampleLink");
            }
        }
    }
