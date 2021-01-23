    [ChildActionOnly]
    public ActionResult GetNews(string category)
    {
        var newsProvider = new NewsProvider();
        var news = newsProvider.GetNews(category);
        return PartialView(news);
    }
