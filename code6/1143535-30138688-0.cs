    public ActionResult Index(int? index)
    {
        if (Request.IsAjaxRequest())
        {
            return PartialView(_attractionList.ElementAt(index));
        }
       return View(_attractionList.First());
    }
