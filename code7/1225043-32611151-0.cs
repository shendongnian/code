    public FileResult GetAttachment()
    {
        byte[] contents = System.IO.File.ReadAllBytes(@"c:\sample.pdf");
        Response.AddHeader("Content-Disposition", "inline; filename=sample.pdf");
        return File(contents, "application/pdf");
    }
