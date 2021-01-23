    IWebElement tableElement = driver.FindElement(By.XPath("/html/body/table"));
    IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
    IList<IWebElement> rowTD;
    foreach (IWebElement row in tableRow)
    {
       rowTD = row.FindElements(By.TagName("td"));
    
       if(rowTD.Count > 9)
       {
          if(rowID[8].Text.Equels("Suspended") && rowID[10].Text.Equels("Publishing Failed");
            //test failed
       }
    }
