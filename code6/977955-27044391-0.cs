        public static IWebElement WaitForElementPresent(this IWebDriver driver, By by)
        {
            try
            {
                return new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(x => x.FindElement(by));
            }
            catch (WebDriverTimeoutException exception)
            {
                throw new AssertionException(string.Format("Element {0} was not found. Page source: {1}{2}",
                                                           by,
                                                           Environment.NewLine,
                                                           driver.PageSource),
                                                           exception);
            }
        }
