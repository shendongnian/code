    IList<IWebElement> links = driver.FindElements(By.TagName("a"));
    IList<IWebElement> listOflinks = new List<IWebElement>();
        
    foreach (IWebElement link in links)
    {
       if (!string.IsNullOrEmpty(link.Text))
          listOflinks.Add(link);
    }
