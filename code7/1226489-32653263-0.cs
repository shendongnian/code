    Actions action = new Actions(driver);
    IWebElement MegaMenu = driver.FindElement(By.CssSelector("#tab-overview"));
    action.MoveToElement(MegaMenu).Build().Perform();
    WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
    IWebElement updateLink = Wait.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Update my details")));
    updateLink.Click();
