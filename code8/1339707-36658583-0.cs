    Actions action = new Actions(Driver);
    action.MoveToElement(/IWebElement here/).Perform();
    action.Click();   
       or
    action.SendKeys(OpenQA.Selenium.Keys.Enter).Perform();
