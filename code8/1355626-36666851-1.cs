    // wait for an element to be present and click it
    driver.Wait(ExpectedConditions.ElementExists(By.Id("..."))).Click();
    // wait for an element to be visible and click it
    driver.Wait(ExpectedConditions.ElementIsVisible(By.Id("...")), 5).Click();
    // wait for an element to be present and click it
    driver.WaitElementPresent(By.Id("...")).Click();
    // wait for an element to be visible and click it
    driver.WaitElementVisible(By.Id("...")).Click();
