    public ActionResult Download()
    {
        var f = Server.MapPath("~/Content/mypdf.pdf");
        var bytes = System.IO.File.ReadAllBytes(f);
        return File(bytes, MimeMapping.GetMimeMapping(f));
    }
    public ActionResult Download2()
    {
        var f = Server.MapPath("~/Content/mypdf.pdf");
        var fileStream = new FileStream(f, FileMode.Open, FileAccess.Read);
        return File(fileStream, MimeMapping.GetMimeMapping(f));
    }
