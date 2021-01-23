    public ActionResult View(int id)
    {
        var pathToTheFile=Server.MapPath("~/Content/Downloads/sampleFile.pdf");
        var fileStream = new FileStream(pathToTheFile,
                                            FileMode.Open,
                                            FileAccess.Read
                                        );
        return  new FileStreamResult(fileStream, "application/pdf");           
    }
