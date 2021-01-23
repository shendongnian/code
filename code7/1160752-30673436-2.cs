    public ActionResult Index(int id)
    {
        var contentArea = id as ContentAreaEnum;
        if(contentArea != null) {
           ViewData["Claims"] = _ctsService.GetClaimsForContentArea(contentArea);
        }
        return View();
    }
