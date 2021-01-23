    //Find the dropdown container and click it
    IWebElement actionMenu = driver.FindElement(By.Id("InitiatorID"));
    actionMenu.Click(); //Feel free to condense this to just driver.FindElement().Click();
    
    //Find the now visible option and click it
    driver.FindElement(By.XPath("//input[@value = Bridget]")).Click();
