    public static IWebElement WaitElementPresent(this IWebDriver driver, By by, int timeout = 10) {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
            .Until(ExpectedConditions.ElementExists(by));
    }
    
    public static IWebElement WaitElementVisible(this IWebDriver driver, By by, int timeout = 10) {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))
            .Until(ExpectedConditions.ElementIsVisible(by));
    }
    
    public static IWebElement Wait(this IWebDriver driver, Func<IWebDriver, IWebElement> condition, int timeout = 10) {
        return new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(condition);
    }
 
