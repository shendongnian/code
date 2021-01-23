    public static bool ValidateSearchResult(string s)
        {
            bool val = false;
            try
            {
                new WebDriverWait(Drivers._driverInstance, new TimeSpan(0, 0, 10)).Until(ExpectedConditions.ElementExists(By.TagName("tbody")));
                IList<IWebElement> StatusColumnData = Drivers._driverInstance.FindElements(By.XPath("//table/tbody/tr/td[2]"));
                foreach (IWebElement element in StatusColumnData)
                {
                    if (element.Text.Contains(s))
                    {
                        val = true;
                        break;
                    }
                    else
                        val = false;
                   return val;
                }
            }
            catch(Exception e)
            {
                throw (e);
            }
        }
