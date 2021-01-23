    public ActionResult Create()
    {
      ViewBag.Message = "From GET";
      return View();
    }
    [HttpPost]
    public ActionResult Create(string someParamName)
    {
      ViewBag.Message = ViewBag.Message + "- Totally new value";
      return View();
    }
