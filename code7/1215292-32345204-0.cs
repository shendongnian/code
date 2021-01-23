    [HttpPost]
    public ActionResult Index(HttpPostedFileBase file)
    {
        WebImage img = new WebImage(file.InputStream);
        if (img.Width > 1000)
            img.Resize(1000, 1000);
        img.Save("path");
        return View();
    }
