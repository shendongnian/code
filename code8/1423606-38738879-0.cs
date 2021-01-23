    driver = new ChromeDriver();
    driver.Manage().Window.Maximize();
    driver.Navigate().GoToUrl("http://jqueryui.com/selectable/");
    
    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3))
    
    wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));
    
    ReadOnlyCollection<IWebElement> lstItems = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("#selectable li")));
    
    builder.ClickAndHold(lstItems[1])
                    .ClickAndHold(lstItems[3])
                    .Click()
                    .Perform();
    driver.SwitchTo().DefaultContent();
