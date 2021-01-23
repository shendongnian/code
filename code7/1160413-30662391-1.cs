    [HttpPost]
    public JsonResult FinaliseQuote(string quote)
    {
        var finalisedQuote = JsonConvert.DeserializeObject<FinalisedQuote>(System.Uri.UnescapeDataString(quote));
    
        // save the file and return an id...
    }
    
    public FileResult DownloadFile(int id)
    {
        var fs = System.IO.File.OpenRead(Server.MapPath(string.Format("~/Content/file{0}.pdf", id)));
    
        // this is needed for IE to save the file instead of opening it
        HttpContext.Response.Headers.Add("Content-Disposition", "attachment; filename=\"filename\""); 
    
        return File(fs, "application/octet-stream");
    }
