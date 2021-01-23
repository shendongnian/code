    IQueryable<News> news = context.News;
    var themesIds = themes.Select(t=>t.Id).ToArray();
  
    news = news.Where(n =>  n.Post.Themes.Any(t=>themesIds.Contains(t.Id))); 
   
    return news.ToList();
