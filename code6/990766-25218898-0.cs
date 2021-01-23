    var context = DataContextFactory.GetDataContext();
    var articles = (from tag in context.Tags
                    join ta in context.ArticleTags on tag.Id equals ta.TagId
                    join article in context.Articles on ta.ArticleId equals article.Id
                    where tag.Title == tagTitle
                       && tag.IsActive == isActiveTag
                    select article).ToList();
