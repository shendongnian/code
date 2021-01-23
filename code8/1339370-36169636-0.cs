        /// <summary>
        /// Returns an element if found, otherwise returns null
        /// </summary>
        /// <param name="by"></param>
        /// <returns></returns>
        internal IWebElement FindElementIfExists(By by)
        {
            IWebElement element = null;
            try
            {
                element = FindElement(@by);
            }
            catch (NoSuchElementException)
            {
                
            }
            return element;
        }
        public void Test()
        {
        	var stopwatch = Stopwatch.StartNew();
        	var timeout = 30 // in minutes
        	browser.GoTo<Page>();
        	while (FindElementIfExists(By.Id("id")) == null && stopwatch.Elapsed.TotalMinutes < timeout)
        	{
        		Thread.Sleep(30); // sleep for 30 seconds
        		browser.GoTo<Page>();
        	}
        	if (stopwatch.Elapsed.TotalMinutes >= timeout)
        		// fail test
        	// continue test        	 
        }
 
