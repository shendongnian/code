    public IList<Article> getArticleByIdWithSortedSubarticles(int ArticleId)
    {
        var query = _articleRepository.Table;
        query = query.Where(a => ArticleId == a.Id)
                     .Select(a => new { article = a, subs = a.SubArticles.OrderBy(s => s.SortOrder) });
    
        return query.AsEnumerable().Select(m => m.article).ToList();
    }
