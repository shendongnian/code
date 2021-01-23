    List<Article> model = new List<Article>();
    foreach (var article in articles)
    {
        foreach (var keyword in keywords)
        {
            if (article.Title.Contains(keyword) || article.Description.Contains(keyword))
            {
                model.Add(article);
                break;
            }
        }
    }
