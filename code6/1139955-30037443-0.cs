    private IWebElement FindElementById(string id)
    {
        return FindElementBy(By.Id, id);
    }
    private IWebElement FindElementByLinkText(string linkText)
    {
        return FindElementBy(By.LinkText, linkText);
    }
    private IWebElement FindElementBy(Func<string, By> finder, string argument)
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(40));
        IWebElement we = null;
        wait.Until<bool>(x =>
        {
            we = x.FindElement(finder(argument));
            bool isFound = false;
            try
            {
                if (we != null)
                    isFound = true;
            }
            catch (StaleElementReferenceException)
            {
                we = x.FindElement(finder(argument));
            }
            return isFound;
        });
        return we;
    }
