    [Test]
        public void ClearChromeHistory()
        {
            //Navigate to History
            driver.Navigate().GoToUrl("chrome://history/");
            //Switch to IFrame
            driver.SwitchTo().Frame("history");
            Thread.Sleep(5000); //Static wait is not recommended
            //Click on 'Clear Browsing Data' Button
            IWebElement clearBrowsingDataButton =  driver.FindElement(By.Id("clear-browsing-data"));
            clearBrowsingDataButton.Click();
            Thread.Sleep(2000); //Static wait is not recommended
            //Swich to Settings IFrame on 'chrome://settings/clearBrowserData' URL
            driver.SwitchTo().Frame("settings");
            Thread.Sleep(5000); //Static wait is not recommended
            //Click on 'Browsing History' checkbox
            IWebElement ClearHistoryCheckbox = driver.FindElement(By.Id("delete-browsing-history-checkbox"));
            ClearHistoryCheckbox.Click();
        }
