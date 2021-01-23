    Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30));
    try
    {
    	Driver.Navigate().GoToUrl(@"https://signin.sandbox.ebay.com/");
    }
    catch (Exception)
    {
        System.Diagnostics.Debug.WriteLine("Some resources are dead!");
    }
    IWait<IWebDriver> wait = new DefaultWait<IWebDriver>(Driver);
    wait.Timeout = TimeSpan.FromSeconds(10);
    wait.PollingInterval = TimeSpan.FromMilliseconds(300);
    wait.Until(d => d.FindElements(By.XPath("//span[text()='SIGN IN']")).Count > 0);
    
    System.Diagnostics.Debug.WriteLine("SIGN IN textbox is loaded");
