    public ActionResult Create()
    {
      BandVM model = new BandVM();
      model.MusicStyleList = new SelectList(db.MusicStyles);
      return View(model);
    }
