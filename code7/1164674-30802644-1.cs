    public ActionResult Index(string id)
    {
        db.Configuration.LazyLoadingEnabled = false;
        string searchString = id;
        var songs = from m in db.Songs
                    select m;
        if (!String.IsNullOrEmpty(searchString))
        {
            songs = songs.Where(s => s.Title.Contains(searchString));
        }
        return Json(songs, JsonRequestBehavior.AllowGet);
    }
