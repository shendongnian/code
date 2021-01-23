    [HttpPost]
    public ActionResult Index(tbl_pics pic, HttpPostedFileBase file)
    {
        ....
        return View(pic); // you are only returning the images here, not the users, or the viewmodel.
    }
