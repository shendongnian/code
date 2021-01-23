    IList<IWebElement> tableTR = driver.FindElement(By.Id("TABLE_ID")).FindElements(By.TagName("tr"));
    
    foreach(IWebElement element in tableTR)
    {
    if(element.GetAttribute("headers").Equals("colSequence")
    {
    //do your stuff...
    }
    }
