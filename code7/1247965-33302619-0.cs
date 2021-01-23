    public ActionResult Index(Combined model)
    {
       var q = _ctx.tblNews.OrderByDescending(x => x.newsCreateDate)
       .Where(x => x.WebsiteID == 2 && x.newsPublish).ToList();
    
       model.NewsList = new List<NewsList>(); // "new it up"
       foreach (var n in q)
       {
           model.NewsList.Add(new NewsList
               {
                   NewsId = n.newsID,
                   NewsTitle = n.newsTitle,
                   NewsStandFirst = n.newsStandFirst,
                   NewsCreateDate = n.newsCreateDate
               }
           );
        }
        return View(model);
    }
