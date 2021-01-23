    public static class WebDriverExtensions
    {        
    	public static IWebElement FindElementIfExists(this IWebDriver driver, By by)
    	{
    		IWebElement result = null;
    
    		try
    		{
    			result = driver.FindElement(by);
    		}
    		catch { }
    
    		return result;
    	}    
    }
