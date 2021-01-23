    [HttpGet]
    public FileResult Download()
    {   
        // Create file on disk
        using (ZipFile zip = new ZipFile())
        {
            zip.AddDirectory(Server.MapPath("~/Directories/hello"));
            //zip.Save(Response.OutputStream);
            zip.Save(Server.MapPath("~/Directories/hello/sample.zip"));
        }
        // Read bytes from disk
        byte[] fileBytes = System.IO.File.ReadAllBytes(
            Server.MapPath("~/Directories/hello/sample.zip"));
        string fileName = "sample.zip";
        // Return bytes as stream for download
        return File(fileBytes, "application/zip", fileName);
    }
