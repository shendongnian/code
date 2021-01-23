        var allArticles = new IEnumerable<Article>();
        allArticles = db.GetAllArticles(); //or whatever method that you have for grabing everything from db
    
       var filteredArticles = allArticles.FinAll(x=>x.ReviewStatus != null && x.ReviewStatus.Count > 0 && x.ReviewStatus.Exists(u=> u.user.Id == 1234) && x.ReviewStatus.Exists(u.otherCriteria = 4321 ));
       foreach(var article in filterArticles)
    {
        var specificReviews_1 = article.ReviewStatus.FinaAll(u=> u.user.Id == 1234).Take(3);
        var specificReviews_2 = article.ReviewStatus.FinaAll(u=> u.user.Id != 1234 && u.otherCriteria = 4321).Take(3);
        article.ReviewStatus = new List<ReviewStatus>();
        article.ReviewStatus.AddRange(specificReviews_1 );
        article.ReviewStatus.AddRange(specificReviews_2 );
    
    }   
    return View("yourView", filterArticles);
