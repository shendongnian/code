    public static IWebDriver GetWebDriverFromElement(this IWebElement element)
    {
        IWebDriver driver = null;
        if (element.GetType().ToString() == "OpenQA.Selenium.Support.PageObjects.WebElementProxy")
        {
            driver = ((IWrapsDriver)element
                             .GetType().GetProperty("WrappedElement")
                             .GetValue(element, null)).WrappedDriver;
        }
        else
        {
            driver = ((IWrapsDriver)element).WrappedDriver;
        }
        return driver;
    }
