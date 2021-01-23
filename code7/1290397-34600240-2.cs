    IList<IWebElement> options = driver.FindElements(By.CssSelector("#dep2 > option")); //get all option tags from the table
    IList<IWebElement> hrefs = driver.FindElements(By.TagName("a")); //get all hrefs
    foreach (IWebElement option in options)
    {
        string value = option.GetAttribute("value");
        string text = option.GetText();
        
        foreach (IWebElement href in hrefs)
        {
            if (href.GetText().equals(text))
            {
                // do what you need
            }
        }
    }
 
