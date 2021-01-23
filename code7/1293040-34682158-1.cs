    public ActionResult Register()
    {
        ViewBag.Datalist = GetGenders();
        return View();
    }
