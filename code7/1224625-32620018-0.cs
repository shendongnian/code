    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
                {
                    try
                    {
                        return d.FindElement(By.ClassName("dl_link 1"));
                    }
                    catch
                    {
                        return null;
                    }
                });
            }
            catch(Exception e)
            {
    
            }
            
    
            ReadOnlyCollection<IWebElement> lists = driver.FindElements(By.ClassName("download_link"));
            lists[0].Click();
