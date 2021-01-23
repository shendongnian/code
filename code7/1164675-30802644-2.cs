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
        var mappedSongs = songs.Select(it => new { Title = it.Title, Artist = it.Artist }).ToList();
        return Json(mappedSongs , JsonRequestBehavior.AllowGet);
    }
