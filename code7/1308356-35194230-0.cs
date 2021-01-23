    IWait<IWebElement> wait = new DefaultWait<IWebElement>(table);
    wait.Timeout = TimeSpan.FromSeconds(5);
    wait.PollingInterval = TimeSpan.FromMilliseconds(300);
    By locator = By.XPath("div/table/tbody/tr");
    ReadOnlyCollection<IWebElement> rows;
    
    wait.Until(e => e.FindElements(locator).Count > 0);
    rows = table.FindElements(locator);
    
    
    foreach (var tr in rows)
    {
    
    	wait = new DefaultWait<IWebElement>(tr);
    	wait.Timeout = TimeSpan.FromSeconds(5);
    	wait.PollingInterval = TimeSpan.FromMilliseconds(300);
    	locator = By.XPath("td");
    	ReadOnlyCollection<IWebElement> cells;
    
    	wait.Until(e => e.FindElements(locator).Count > 0);
    	cells = tr.FindElements(locator);
    
    	foreach (var td in cells)
    	{
    		if (td.GetAttribute("innerHTML").Contains("some stuff"))
    		{
    			// This part is always reached, so condition is satisfied. > x is the relevant value, it is assigned the proper value when the error is thrown, but it still throws an exception.
    			wait = new DefaultWait<IWebElement>(td);
    			wait.Timeout = TimeSpan.FromSeconds(5);
    			wait.PollingInterval = TimeSpan.FromMilliseconds(300);
    			locator = By.XPath("div/a[2]");
    			IWebElement link2;
    
    			wait.Until(e => e.FindElements(locator).Count > 0);
    			try
    			{
    				link2 = td.FindElement(locator);
    			}
    			catch (NoSuchElementException ex)
    			{
    				throw new NoSuchElementException("Unable to find element, locator: \"" + locator.ToString() + "\".");
    			}
    			x = link2.GetAttribute("href").Split('/')[4];
    			bmID = getBookmakerID(bmName);
    		}
    		if (td.GetAttribute("class").Contains("some other stuff"))
    		{
    
    		}
    	}
    }
