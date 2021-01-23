    Class Actions {
    
            public static IWebDriver ClickOn(IWebDriver driver, string button) 
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementExists(By.XPath(button)));
                driver.FindElement(By.XPath(button)).Click();
                return driver;
            }
    }
