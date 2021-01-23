     var db = new ApplicationDbContext()
    var CountNews = db.tbl_GroupNews.News.Count();
    ViewBag.Counter = CountNews;
    
    and if you are not using lazy loading then can get by
    var db = new ApplicationDbContext()
    var CountNews = db.tbl_GroupNews.Include(w=>w.News).News.Count();
    ViewBag.Counter = CountNews;
