    IList<IWebElement> options = driver.FindElements(By.CssSelector("#dep2 > option")); //get all option tags from the table
    IList<IWebElement> hrefs = driver.FindElements(By.TagName("a")); //get all hrefs
    foreach (IWebElement option in options)
    {
        string value = option.GetAttribute("value");
        string text = option.Text;
        
        foreach (IWebElement href in hrefs)
        {
            if (href.Text.equals(text))
            {
                // do what you need with the href
            }
        }
    }
 
