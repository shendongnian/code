    public static IWebElement WaitAndFindElement(Func<IWebDriver, IWebElement> expectedCondtions, int timeoutInSeconds)
    {
        WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        
         return webDriverWait.Until(expectedCondtions);
     }
    //Now you can call above function as
    IWebElement el = WaitAndFindElement(ExpectedConditions.ElementExists(By), int timeoutInSeconds);
