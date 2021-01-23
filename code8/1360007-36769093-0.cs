    IWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
    wait.Timeout = TimeSpan.FromSeconds(10);
    wait.PollingInterval = TimeSpan.FromMilliseconds(300);
    By by = By.Id("iframe09328");
    try
    {
        // Switch to the parent iframe
    	wait.Until(d => d.FindElements(by).Count > 0);        
        IWebElement parentFrame = driver.FindElements(by).First();
        driver.SwitchTo().Frame(parentFrame);
        // Switch to the inner iframe
        by = By.Id("iframe00237");
        wait.Until(d => d.FindElements(by).Count > 0);
        IWebElement childFrame = driver.FindElements(by).First();
        driver.SwitchTo().Frame(childFrame);
    }
    catch (Exception)
    {
    	throw new NoSuchElementException("Unable to find element, locator: \"" + by.ToString() + "\".");
    }
