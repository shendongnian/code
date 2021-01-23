        IQueryable<ArticleViewModel> requestedItems =
            articlesOfTopicsWithTopicName.Select(article =>
                new ArticleViewModel()
                {
                    Title = article.Title,
                    Introduction = article.Introduction,
                    ...
                }
        // delayed execution, nothing has been performed yet
        return requestedItems.ToList();
        // execute and return the list
    }
        
