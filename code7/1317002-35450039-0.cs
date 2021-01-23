      public List<String> policy1Details = new List<String>();
        public void PolicySummary1(int i)
        {
            //var driver = new FirefoxDriver();
            policy1Details.Clear();
            var psummary = driver.FindElements(By.XPath("//text()"));//give your xPath.
           
            //var psummary = driver.FindElement(By.XPath("//div[@id='PolicyDetails_" + i + "']/div/table"));
            foreach (IWebElement d in psummary)
            {
                //resultText.Add(d.Text);
                policy1Details.Add(d.Text);
            }
        }
