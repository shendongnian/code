    public ActionResult Download(string fileName)
    {
        var rootPath = Server.MapPath("~/ClientDocument/");
        if (Path.GetInvalidFileNameChars().Contains(fileName))
            throw new Exception();
        byte[] fileBytes = System.IO.File.ReadAllBytes(rootPath + fileName);
        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
    }
