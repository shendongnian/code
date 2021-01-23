    [HttpPost]
    public ActionResult getRssFeed(string rssurl)
    {
        ViewBag.Feed = rssurl ;
        return View();
    }
