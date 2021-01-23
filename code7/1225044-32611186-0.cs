    public ActionResult GetAttachment()
    {
        var fileStream = new FileStream(Server.MapPath("~/Content/files/sample.pdf"), 
                                         FileMode.Open,
                                         FileAccess.Read
                                       );
        var fsResult = new FileStreamResult(fileStream, "application/pdf");
        return fsResult;
    }
