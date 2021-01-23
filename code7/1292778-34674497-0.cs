    result.Articles.AddRange(myArticles.AsParallel().Select(article =>
        new ArticleMinimal()
        {
            ArticleNumber = article.ArticleNumber,
            Description = article.Description,
            IsMaterial = false,
            Price = article.PortionPrice.HasValue ? article.PortionPrice.Value : decimal.Zero,
            Quantity = 1,
            ValidFrom = new DateTime(1900, 1, 1),
            ValidTo = new DateTime(2222, 1, 1)
        })
    );
