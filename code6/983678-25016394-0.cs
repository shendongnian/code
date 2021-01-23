    [HttpPost]
    public ActionResult UploadToFlickr(HttpPostedFileBase file, FormCollection form)
    {
        // Upload logic goes here
    }
    [HttpGet]
    public ActionResult UploadToFlickr()
    {
        // Callback logic goes here
        return RedirectToAction("Index");
    }
