    public void SearchArticles()
    {
        var articles = SearchService
            .PerformSearch<ArticleResultItem>("/sitecore/content", "ArticlePageTemplate")
            .Where(item => item.SubHeader == "News").ToList();
        foreach (var article in articles){
            var articleName = article;
            // Do something with the list here....
        }
    }
