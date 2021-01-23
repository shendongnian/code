    IWebElement baseTable = driver.FindElement(By.ClassName(TableID));
    // gets all table rows
    ICollection<IWebElement> rows = baseTable.FindElements(By.TagName("tr"));
    // for every row
    IWebElement matchedRow = null;
    foreach (var row in rows)
    {    
        Console.WriteLine(row.FindElement(By.XPath("td/a")).GetAttribute("href"));    
    }
