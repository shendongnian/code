    public ActionResult Upload(HttpPostedFileBase file, string btnSubmit)
    {
        if (file != null && file.ContentLength > 0)
        {
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
            file.SaveAs(path);
        }
        return Content("Success");
    }
