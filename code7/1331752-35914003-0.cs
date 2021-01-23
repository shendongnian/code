    public ActionResult Index()
    {
          List<className> dto = (from a in _db.User_Role
                     join b in db.Site on a.SiteID equals b.SiteID 
                      select (new classname { UserID =a.UserID , UserName =a.UserName , SiteID =a.SiteID , SiteName =b.SiteName })).ToList();
         return View(dto);
    }
