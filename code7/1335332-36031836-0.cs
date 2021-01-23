    [HttpPost]
    public ActionResult Index(Car car)
    {
       if (!Request.IsAjaxRequest()) {
            return PartialView("ajexview");            
        }
        return View("About");
    }
