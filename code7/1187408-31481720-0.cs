    public static class WebDriverExtensions
    {
        /// <summary>
        /// Try finding the element for timeoutInSeconds until throwing "no matching element"
        /// </summary>
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds <= 0) return driver.FindElement(@by);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(drv => drv.FindElement(@by));
        }
    }
	
	
	
