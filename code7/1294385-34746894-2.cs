    IWebElement tableElement = driver.FindElement(By.XPath("/html/body/table"));
    IList<IWebElement> tableRow = tableElement.FindElements(By.TagName("tr"));
    IList<IWebElement> rowTD;
    foreach (IWebElement row in tableRow)
    {
       rowTD = row.FindElements(By.TagName("td"));
    
       if(rowTD.Count > 9)
       {
          if(rowTD[8].Text.Equals("Suspended") && rowTD[10].Text.Equals("Publishing Failed");
          //test failed
       }
    }
