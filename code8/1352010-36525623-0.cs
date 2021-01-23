    public IEnumerable<Article> GetArticles() {
        using (var db = new ArticlesContext()) {
            return db.Articles.AsEnumerable();
        }
    }
