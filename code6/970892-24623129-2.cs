    [HttpPost]
    public ActionResult AddMovie()
    {
        ViewData["SQ"] = db.MovieType.ToList();
        return View();
    }
