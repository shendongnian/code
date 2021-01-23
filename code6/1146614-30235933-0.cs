    public FileResult ZipFiles(...)
    {
       // create a temporary file
        return File("path/to/file.zip", System.Net.Mime.MediaTypeNames.Application.Octet);
    }
