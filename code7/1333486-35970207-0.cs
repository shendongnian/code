            public static IWebElement FindElement( IWebElement element, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => element);
            }
            return element;
        }
