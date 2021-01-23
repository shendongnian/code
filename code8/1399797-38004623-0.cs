    String searchText = "Application Name";
    IReadOnlyCollection<IWebElement> spans = driver.FindElements(By.CssSelector("td > span.Tree_Span"));
    foreach (IWebElement span in spans)
    {
        if (span.Text == searchText)
        {
            span.Click();
            break;
        }
    }
