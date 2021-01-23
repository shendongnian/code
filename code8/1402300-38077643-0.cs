    IList<IWebElement> TRCollection = driver.FindElement(By.Id("tableId")).FindElements(By.TagName("tr"));
    IList<IWebElement> TDCollection;
    
    foreach(IWebElement element in TRCollection )
    {
    //td list from each row
    TDCollection = element.FindElements(By.TagName("td"));
    
    string column1 = TDCollection[0].Text;
    ...
    }
