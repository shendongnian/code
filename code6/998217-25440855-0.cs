    public IEnumerable<string> ExtractLinks(string htmlFile)
    {
        var page = CQ.CreateFromFile(htmlFile);
        return page.Select("a").Where(tag => tag.HasAttribute("href")).Select(tag => tag.GetAttribute("href"));
    }
