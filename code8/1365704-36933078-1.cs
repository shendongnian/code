    [HttpPost]
    public ActionResult Mymethod(string name)
    {
        ViewBag.Message = "Hello what is ur name ???";
        ViewBag.Name = name;
        return View();
    }
