    public ActionResult Index(int page = 1, int pageSize = 10)
    {
        var inlägg = db.Gästbok.OrderByDescending(g => g.Datum).ToList();
        var model = new PagedList<Gästbok>(inlägg, page, pageSize);
        return View(model);
    }
