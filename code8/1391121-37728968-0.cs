    public static bool FindInTableAndClick(IWebDriver driver, string TableID, string StrToFind)
        {
            IWebElement tableElement = driver.FindElement(By.XPath("//table[contains(@id, '" + TableID + "')]"));
            ICollection<IWebElement> trCollection = tableElement.FindElements(By.XPath("id('" + tableElement.GetAttribute("id") + "')/tbody/tr"));
            ICollection<IWebElement> tdCollection = null;
            foreach (var tr in trCollection)
            {
                if (tdCollection != null)
                {
                    foreach (var td in tdCollection)
                    {
                        if (td.Text.ToLower().Contains(StrToFind.ToLower()))
                        {
                            td.Click();
                            return true;
                        }
                    }
                }
                i++;
            }
            return false;
        }
