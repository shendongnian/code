    public class Links
    {
        public string LinkName { get; set; }
        public string href { get; set; }
        public string newPageUrl { get; set; }
    }
    string newPageUrl = "";
    string linkName = "";
    string href = "";
    List<Links> links = new List<Links>();
    foreach (IWebElement item in _driver.FindElements(By.TagName("a")))
    {
        href = item.GetAttribute("href");
        linkName = item.text();
        item.click();
        newPageUrl = driver.Url();
        links.Add(new Links
             {
                 NewPageUrl  = newPageUrl,
                 Href = href,
                 LinkName = linkName
             });
        driver.Navigate().Back();
    }
