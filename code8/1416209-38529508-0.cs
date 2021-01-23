     string mainWindow = driver.WindowHandle;
    var w = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(20));
    var copy = w.Until(ExpectedConditions.ElementIsVisible(By.Id("copyButton")));
    copy.Click();
    driver.SwitchTo().Window(driver.WindowHandles.Last());
    //do your stuff for filling the form in popup window
    
