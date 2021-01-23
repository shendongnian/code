    public static void Click(this IWebElement element, TestTarget target)
    {
        if (target.IsInternetExplorer)
        {
            var actions = new Actions(target.Driver);
            actions.MoveToElement(element).Perform();
            Thread.Sleep(500); // wait for the mouseover popup to appear
            element.SendKeys(Keys.Escape); // to close the popup (if any)
            actions.MoveToElement(element).DoubleClick().Perform(); // simple click is sometimes not enough in IE
        }
        else
        {
            element.Click();
        }
    }
