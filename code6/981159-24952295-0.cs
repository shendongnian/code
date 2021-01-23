    using System;
    using System.Configuration;  
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome; 
    using OpenQA.Selenium.IE;     
    using OpenQA.Selenium.Firefox;
    using TechTalk.SpecFlow;
    
    namespace Automation
    {
        [Binding]    
        public class GoogleTests_Chrome
        {
            private IWebDriver _driver;
    
            [BeforeScenario]
            public void FixtureSetup()
            {
                switch (ConfigurationManager.AppSettings["Browser"])
                {
                    case "Chrome":
                        _driver = new ChromeDriver();
                        _driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
                        _driver.Manage().Cookies.DeleteAllCookies();
                        _driver.Manage().Window.Maximize();
                        break;
                    case "Firefox":
                        _driver = new FirefoxDriver();
                        _driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
                        _driver.Manage().Cookies.DeleteAllCookies();
                        _driver.Manage().Window.Maximize();
                        break;
                    case "IE":
                        _driver = new InternetExplorerDriver();
                        _driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
                        _driver.Manage().Cookies.DeleteAllCookies();
                        _driver.Manage().Window.Maximize();
                        break;
                    default:
                        Console.WriteLine("Defaulting to Firefox");
                        _driver = new FirefoxDriver();
                        _driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 30));
                        _driver.Manage().Cookies.DeleteAllCookies();
                        _driver.Manage().Window.Maximize();
                        break;
                }
            }
    
            [Given("I have navigated to (.*) in my web browser")]
            public void TestSetUp(string url)
            {
                _driver.Navigate().GoToUrl(url);
            }
    
            [Then("I want to verify that the page has loaded successfully")]
            public void GooglePageTitle()
            {
                Assert.AreEqual("Google", _driver.Title);
            }
    
            [AfterScenario]
            public void FixtureTearDown()
            {
                if (_driver != null) _driver.Quit();
            }
        }
    }
