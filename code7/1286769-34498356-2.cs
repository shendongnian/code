    public ActionResult Download()
    {
        var f = Server.MapPath("~/Content/mypdf.pdf");
        var fileStream = new FileStream(f,FileMode.Open,FileAccess.Read);
        return new FileStreamResult(fileStream, MimeMapping.GetMimeMapping(f));
    }
