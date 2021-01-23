    [Authorize]
    public ActionResult GetPdfContent(string fileCode)
    {
        // this will remove path traversal attempts like '..'
        var fileName = Path.GetFileName(fileCode);
        // this will get you the file extension
        var fileExtension = Path.GetExtension(fileName).ToLowerInvariant();
        if (fileExtension != ".pdf")
            return View("ErrorNotExistsView");
        return File("~/files/content/" + fileName, "application/pdf", Server.UrlEncode(fileName));   
        }
    }
