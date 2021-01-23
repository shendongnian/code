    static ArticleContent GetArticleContent(int ID, 
       params Expression<Func<ArticleContent, object>>[] includes)
    {
       using(var ctx = new MyContext())
       {
          var acQuery =  _ctx.ArticleContents.Include(a=> a.Metadata);
          foreach(var include in includes)
            acQuery = acQuery.Include(include);
          return acQuery.Single(a => a.Id == model.BaseID);
       }
    }
