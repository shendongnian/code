    By byId = By.Id("menu-item-33");
    By css = By.CssSelector("a[href*='product-category/accessories']");
    
    Actions action = new Actions(_driver);
    IWebElement we = _driver.FindElement(byId);
    action.MoveToElement(we).Build().Perform();
    new WebDriverWait(_driver,TimeSpan.FromSeconds(2)).Until(ExpectedConditions.ElementIsVisible(css)).Click();
