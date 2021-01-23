    Thread.Sleep(6000);
    driver.SwitchTo().Frame(driver.FindElement(By.Id("scWebEditRibbon")));
    var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
    var clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[@data-sc-    id='QuickRibbon']")));
    clickableElement.Click(); //click to drop down the toolbar
    driver.SwitchTo().DefaultContent();
