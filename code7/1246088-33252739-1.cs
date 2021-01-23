    //Taking all the table rows in list collection.    
    IList<IWebElement> tableTR = driver.FindElement(By.Id("TABLE_ID")).FindElements(By.TagName("tr"));
        
        //Loop on rows
        foreach(IWebElement element in tableTR)
        {
        //for every row if the header tag equals what you need you do the code inside.
        if(element.GetAttribute("headers").Equals("colSequence")
        {
        //do your stuff...
        }
        }
