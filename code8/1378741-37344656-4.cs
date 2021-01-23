    [HttpPost]
    public ActionResult UploadFile(HttpPostedFileBase file) 
    { 
        // here you are working with uploaded file
        return View("Index"); 
    }
    [HttpPost]
    public ActionResult Index(List<Album> list)
    {
        // here you are working with checkbox list items
        return View();
    }
