     public ActionResult Index(HttpPostedFileBase file)
        {
            Picture newPix = file;
            if (newPix.File.ContentLength > 0)
            {
                var fileName = Path.GetFileName(pic.File.FileName);
                //var fileName = pic.File.FileName;
                var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                pic.File.SaveAs(path);
            }
            return RedirectToAction("Index");
        }
