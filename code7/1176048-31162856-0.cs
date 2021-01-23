    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.PhantomJS;
    
    namespace Test.Tests
    {
        /// <summary>
        /// A static factory object for creating WebDriver instances
        /// </summary>
        public class WebDriverFactory
        {
            public IWebDriver Driver;
            
    		protected WebDriverFactory(BrowserType type)
            {
                Driver = WebDriver(type);            
            }
    
            [TestFixtureTearDown]
            public void TestFixtureTearnDown()
            {
                Driver.Quit();
            }
    
            /// <summary>
            /// Types of browser available for proxy examples.
            /// </summary>
            public enum BrowserType
            {
                IE,
                Chrome,
                Firefox,
                PhantomJS
            }
    
            public static IWebDriver WebDriver(BrowserType type)
            {
                IWebDriver driver = null;
    
                switch (type)
                {
                    case BrowserType.IE:
                        driver = IeDriver();
                        break;
                    case BrowserType.Firefox:
                        driver = FirefoxDriver();
                        break;
                    case BrowserType.Chrome:
                        driver = ChromeDriver();
                        break;
                    default:
                        driver = PhanthomJsDriver();
                        break;
                }
    
                return driver;
            }
    
            /// <summary>
            /// Creates Internet Explorer Driver instance.
            /// </summary>
            /// <returns>A new instance of IEDriverServer</returns>
            private static IWebDriver IeDriver()
            {
                InternetExplorerOptions options = new InternetExplorerOptions();
                options.EnsureCleanSession = true;
                IWebDriver driver = new InternetExplorerDriver(options);
                return driver;
            }
    
            /// <summary>
            /// Creates Firefox Driver instance.
            /// </summary>
            /// <returns>A new instance of Firefox Driver</returns>
            private static IWebDriver FirefoxDriver()
            {
                FirefoxProfile profile = new FirefoxProfile();
                IWebDriver driver = new FirefoxDriver(profile);
                return driver;
            }
    
    
            /// <summary>
            /// Creates Chrome Driver instance.
            /// </summary>
            /// <returns>A new instance of Chrome Driver</returns>
            private static IWebDriver ChromeDriver()
            {
                ChromeOptions chromeOptions = new ChromeOptions();
                IWebDriver driver = new ChromeDriver(chromeOptions);
                return driver;
            }
    
            /// <summary>
            /// Creates PhantomJs Driver instance..
            /// </summary>
            /// <returns>A new instance of PhantomJs</returns>
            private static IWebDriver PhanthomJsDriver()
            {
                PhantomJSDriverService service = PhantomJSDriverService.CreateDefaultService();
                if (proxy != null)
                IWebDriver driver = new PhantomJSDriver(service);
                return driver;
            }
        }
    }
    
    
