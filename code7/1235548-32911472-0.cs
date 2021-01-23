    var ThisArticle = (from Article in DarunamaEntity.ArticleNews
        where Article.IdArticleNews == ID_int
        select new
        {
            AID = Article.IdArticleNews,
            Views = Article.CountUserVisit,
            TextTitle = Article.TilteTextNews,
            MainImageAddress = Article.ImageUrlMain,
            Brief = Article.brief,
            Content = Article.BodyTextNews
        })
        .ToList()  // Convert from LINQ over SQL to LINQ over Objects
        .Select(Article=> new {
            AID = Article.IdArticleNews,
            Views = Article.CountUserVisit,
            TextTitle = Article.TilteTextNews,
            MainImageAddress = TransformThis(Article.ImageUrlMain),
            Brief = Article.brief,
            Content = Article.BodyTextNews
        });
    JsonExport = serials.Serialize(ThisArticle);
