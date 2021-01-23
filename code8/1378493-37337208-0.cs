    [HttpPost]
    public ActionResult Index(List<Album> list)
    {
        var selected = list.Where(x => x.Checked).Select(x => x.Name);
        ViewBag.Values = String.Join(", ", selected );
        return View(list);
    }
