    ReadOnlyCollection<IWebElement> links = driver.FindElements(By.TagName("a"));
    foreach (IWebElement link in links)
    {
        String href = link.GetAttribute("href");
        // do something with href
    }
