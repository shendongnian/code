    public static class WebDriverExtension
    {
        public static ReadOnlyCollection<IWebElement> FindElementsBy(this IWebDriver driver, By by, int timeoutSecond = 0)
        {
    	    IWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
    	    wait.Timeout = TimeSpan.FromSeconds(timeout);
    	    wait.PollingInterval = TimeSpan.FromMilliseconds(300);
    	    try
    	    {
    	    	wait.Until(d => d.FindElements(by).Count > 0);
    	    	return driver.FindElements(by);
    	    }
    	    catch (Exception)
        	{
    	    	throw new NoSuchElementException("Unable to find element, locator: \"" + by.ToString() + "\".");
    	    }
        }
    
        public static ReadOnlyCollection<IWebElement> FindElementsBy(this IWebElement element, By by, int timeout = 0)
        {
	        IWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
	        wait.Timeout = TimeSpan.FromSeconds(timeout);
	        wait.PollingInterval = TimeSpan.FromMilliseconds(300);
	        try
	        {
	        	wait.Until(e => e.FindElements(by).Count > 0);
	    	    return element.FindElements(by);
	        }
	        catch (Exception)
	        {
		        throw new NoSuchElementException("Unable to find element, locator: \"" + by.ToString() + "\".");
	        }
        }
    }
