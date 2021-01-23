    [HttpPost]
    public ActionResult Upload(HttpPostedFileBase file)
    {
    var Image = Path.GetFileName(file.FileName);
    string path = Path.Combine(Server.MapPath("~/images/Attachment"), Image);
    file.SaveAs(path);
    }
