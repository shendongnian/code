    List<IWebElement> options = driver.FindElements(By.CssSelector("#dep2 > option")); //get all option tags from the table
    
    foreach (IWebElement option in options)
    {
        string value = option.GetAttribute("value");
        string text = option.GetText();
    }
 
