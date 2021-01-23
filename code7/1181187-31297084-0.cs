    private static void sendKeys(IWebElement element, string text)
    {
        element.Click();
        Actions actions = new Actions(driver);
        foreach (char c in text)
        {
            actions.SendKeys(c.ToString())
                .Perform();
        }
    }
