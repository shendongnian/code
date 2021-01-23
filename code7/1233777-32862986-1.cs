    int linkCount = driver.FindElements(By.CssSelector("a[href]")).Count;
    List<string> links = new List<string>();
    for (int i = 0; i < linkCount; i++)
    {
        List<IWebElement> linksToClick = driver.FindElements(By.CssSelector("a[href]")).ToList();
        if (linksToClick.Count < i)
            links.Add(linksToClick[i].GetAttribute("href"));
    }
