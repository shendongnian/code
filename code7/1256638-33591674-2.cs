    public Task<List<List<string>>> GetPages(string base_url, int num_pages)
    {
        var webGet = new HtmlWeb();
        var task = Task.Factory.StartNew(() => 
        {
            var pages = new List<List<string>>();
            for (int i = 0; i <= num_pages; i++)
            {
                UpdateMessage("Fetching page " + i + " of " + num_chapters + ".");
                var page = new List<string>();
                var page_source = webGet.Load(url+i);
                // (...)
                page.Add(url+i);
                page.Add(source);
                pages.Add(page);
            }
            return pages;
        });
    
        return task;
    }
