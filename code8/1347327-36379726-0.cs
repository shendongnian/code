    using Model;
    public List<Article> GetArticleList() {
    
        using(var db = new ArticlesContext()) {
            return db.Articles.ToList();
        }
    }
