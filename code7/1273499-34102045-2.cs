    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium;
    
    class Test
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.gmail.com/");
            IWebElement query = driver.FindElement(By.Id("Email"));
            query.SendKeys("my.email@gmail.com");
            query = driver.FindElement(By.Id("next"));
            query.Click();
            // now you just have to do the same for the password page
            
            driver.Quit();
        }
    }
