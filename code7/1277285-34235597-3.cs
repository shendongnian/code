    [HttpPost]
    public ActionResult Create(string someParamName,string Message)
    {
      ViewBag.Message = ViewBag.Message + "- Totally new value";
      return View();
    }
