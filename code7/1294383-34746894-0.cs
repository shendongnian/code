    IWebElement tableElement = driver.FindElement(By.XPath("/html/body/table"));
    IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
    IList<IWebElement> rowTD;
    foreach (IWebElement row in tableRow)
    {
       rowTD = row.FindElements(By.TagName("td"));
    
       if(rowTD.Count > 9)
       {
          string td8 = rowID[8].Text;
          string td10 = rowID[10].Text;
       }
    }
