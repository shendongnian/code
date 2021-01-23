    List<IWebElement> result = new List<IWebElement>();
    IList<IWebElement> tableRows = browser.FindElements(By.XPath("id('column2')/tbody/tr"));
    foreach (IWebElement rows in tableRows)
    {
        IList<IWebElement> allColumns =row.FindElements(By.TagName("td"));
        //and how allColumns[0] +1 etc .... gives you each values, including nulls
    }
