    public class WaitForElement
        {
            public int count = 0;
            public void WaitFE(string Xpath,IWebDriver webDriver)
            {
                try
                {
                    while (!(count < 10 && (webDriver.FindElement(By.XPath(Xpath)).Displayed)))
                    {
                        count = 0;
                        return;
                    }
                }
    
                catch
                {
                    count++;
                    WaitFE(Xpath, webDriver);
                }
    
            }
