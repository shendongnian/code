    public ActionResult Index(int id)
    {
        ViewData["Claims"] = _ctsService.GetClaimsForContentArea((ContentAreaEnum)id);
        return View();
    }
