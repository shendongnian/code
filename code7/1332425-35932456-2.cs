    [ChildActionOnly]
    public ActionResult Index()
    {
        tapnamron_PNMSiteMenu ent = new tapnamron_PNMSiteMenu();
        return PartialView(ent.GetSiteMenu().ToList()); // .ToList() not necessary as the view is IEnemerable<T>
    }
 
