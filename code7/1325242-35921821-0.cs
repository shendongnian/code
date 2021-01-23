    IWebElement element1 = Drivers._driverInstance.FindElement(locator);
    if (((RemoteWebDriver)Drivers._driverInstance).Capabilities.BrowserName == "internet explorer")
    {
        element1.SendKeys(Keys.Tab);
        element1.SendKeys(Keys.Enter);
    }
    else
    {
        element1.Click();
    }
