    ReadOnlyCollection<IWebElement> links = driver.FindElements(By.XPath("//span/@value"));
    
    foreach(IWebElement link in links)
    {
        string text = link.Text;
        Console.WriteLine(text);
    }
