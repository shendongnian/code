    int linkCount = driver.FindElements(By.TagName("a")).Count;
    string[] links = new string[linkCount];
    // WRITE OUT HOM MANY links you have
    for (int i = 0; i < linkCount; i++)
    {
        List<IWebElement> linksToClick = driver.FindElements(By.CssSelector("a[href]")).ToList();
        // ASSERT THAT YOU HAVE THE SAME AMOUNT HERE
        If (links.Count != linksToClick.Count)
             // your logic here
        links[i] = linksToClick[i].GetAttribute("href");
    }
