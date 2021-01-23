    //if (dropdown option value == x)
        if (ElementExists(By.XPath(xpathHiddenElement))
          //log what you want to or do some other check
        else
          //log what you want to or do some other check
    public bool ElementExists(By by)
    {
        try
        {
            IWebElement element = driver.FindElement(by);
            return true;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
