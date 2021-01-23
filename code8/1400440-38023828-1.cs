    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    wait.Until(d => !d.FindElement(By.Id("busy")).Displayed);
    // Click first month
    driver.FindElement(By.CssSelector(".bootstrap-select.select-month > button")).Click();
    System.Threading.Thread.Sleep(1000);
    string targetMonth = "Februar";
    driver.FindElement(By.XPath("//span[contains(text(),'" + targetMonth + "')]/..").Click();
    // Click project type
    System.Threading.Thread.Sleep(1000);
    driver.FindElement(By.CssSelector("button[data-id='projecttype']")).Click();
    System.Threading.Thread.Sleep(1000);
    string targetType = "In-house project";
    driver.FindElement(By.XPath("//span[contains(.,'" + targetType + "')]/..").Click();
