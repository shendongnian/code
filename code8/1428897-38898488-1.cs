    public IActionResult GetDocument(int id)
    {
        var filename = $"folder/{id}.pdf";
        Response.Headers["Content-Disposition"] = $"inline; filename={id}.pdf";
        var fileContentResult = new FileContentResult(System.IO.File.ReadAllBytes(filename), "application/pdf")
        {
            FileDownloadName = $"{id}.pdf"
        };
        // I need to delete file after me
        System.IO.File.Delete(filename);
        return fileContentResult;
    }
  
