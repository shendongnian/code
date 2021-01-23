    IList<IWebElement> links = driver.FindElements(By.TagName("a"));
    IList<IWebElement> listOflinks = new List<IWebElement>();
        
    for(int i = 0 ; i < links.Count ; i++)
    {
       links = driver.FindElements(By.TagName("a"));
       if (!string.IsNullOrEmpty(link[i].Text))
          links[i].Click();
    }
