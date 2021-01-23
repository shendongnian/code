    foreach(var link in reviewLinks)
    {
        if(link.Text.Equals("Review"))
        {
            link.Click();
            driver.FindElement(By.Id("ctlSeverity")).Click();
            driver.FindElement(By.XPath("//*[@value='75']")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.CssSelector("#rblSelectedAction_0")).Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElement(By.Id("TextBox1")).SendKeys("AutoTest");
            driver.FindElement(By.Id("ctlActionPlan")).SendKeys("AutoTest");
            driver.FindElement(By.Id("ctlManagementResponse")).SendKeys("AutoTest");
            driver.FindElement(By.Id("LinkButton1")).Click();
        }
    }
