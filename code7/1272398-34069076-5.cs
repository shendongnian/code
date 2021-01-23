    public static class WebDriverExtensionMethods
    {
        private static IWebElement WaitAndFindElementInternal(IWebDriver webDriver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return webDriver.FindElement(by);
        }
        public static IWebElement WaitAndFindElement(this Driver driver, By by, int timeoutInSeconds)
        {
            return WaitAndFindElementInternal(driver.Instance, by, timeoutInSeconds);
        }
        public static IWebElement WaitAndFindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            return WaitAndFindElementInternal(driver, by, timeoutInSeconds);
        }
    }
