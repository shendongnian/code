            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30));
            try
            {
                Driver.Navigate().GoToUrl(@"https://signin.sandbox.ebay.com/");
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Some resources are dead!");
            }
            var attempts = 0;
            while (attempts < 2)
            {
                try
                {
                    IWait<IWebDriver> wait = new DefaultWait<IWebDriver>(Driver);
                    wait.Timeout = TimeSpan.FromSeconds(20);
                    wait.PollingInterval = TimeSpan.FromMilliseconds(300);
                    wait.Until(d => d.FindElements(By.XPath("//span[text()='SIGN IN']")).Count > 0);
                    break;
                }
                catch (WebDriverException)
                {
                    attempts++;
                }
            } 
