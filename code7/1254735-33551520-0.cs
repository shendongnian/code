    [ChildActionOnly]
    [OutputCache(Duration = 5 * 60)]
    public ActionResult Header(string section)
    {
        var info = new HeaderInfo
        {
            Section = section,
            Today = DateTime.Now
        };
        return PartialView("_header", info);
    }
