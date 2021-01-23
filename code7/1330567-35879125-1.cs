    using(MovieEntities db = new MovieEntities()){
      var searchFilter=db.Moviess.AsQueryable();
      foreach(var word in txtSearch.Text.Split(' '))
      {
        searchFilter=searchFilter.Where(f=>f.Name.Contains(word));
      }
      /* Print */  
