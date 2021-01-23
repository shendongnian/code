            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("Your Address Login");
            IWebElement query = driver.FindElement(By.Id("username"));
            query.SendKeys("Your Username");
            query = driver.FindElement(By.Id("password"));
            query.SendKeys("Your Password");
            query.Submit();
