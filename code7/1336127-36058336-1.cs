    public static class MyExtensionMethodsOrWhateverNameYouLike
    {
        public static void Click(this IWebElement element, IWebDriver driver)
        {
            //driver.DoSomething();
            element.Click();
        }
    }
