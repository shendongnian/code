    public ActionResult Index(int id)
    {
        if(Enum.IsDefined(typeof(ContentAreaEnum), id)) {
           ViewData["Claims"] = _ctsService.GetClaimsForContentArea((ContentAreaEnum)id);
        }
        return View();
    }
