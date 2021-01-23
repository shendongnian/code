    public ActionResult Download4()
    {
        var f = Server.MapPath("~/Content/mypdf.pdf");
        var fileStream = new FileStream(f, FileMode.Open, FileAccess.Read);
        return File(fileStream, MimeMapping.GetMimeMapping(f),"MyfileNiceFileName.pdf");
    }
