    public ActionResult Download()
    {
        var f = Server.MapPath("~/Content/mypdf.pdf");
        var bytes = System.IO.File.ReadAllBytes(f);
        return new FileContentResult(bytes, MimeMapping.GetMimeMapping(f));
    }
