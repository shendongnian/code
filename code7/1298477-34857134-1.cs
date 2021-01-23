    public FileResult TestDownload()
    {
        HttpContext.Response.ContentType = "application/pdf";
        FileContentResult result = new FileContentResult(System.IO.File.ReadAllBytes("YOUR PATH TO PDF"), "application/pdf")
        {
            FileDownloadName = "test.pdf"
        };
        return result;                                
    }
