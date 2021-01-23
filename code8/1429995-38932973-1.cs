    [HttpPost]
    public ActionResult DeletePages(string[] titles)
    {
        removePages(titles);
        List<WikiPage> pages = db.WikiPages.ToList();
        return View(pages);
    }
