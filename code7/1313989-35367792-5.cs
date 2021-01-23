    [HttpPost]  // some browsers have URL length limits
    [ValidateInput(false)] // or throws HttpRequestValidationException
    public ActionResult Index(string xHtml)
    {
        Response.ContentType = "application/pdf";
        Response.AppendHeader(
            "Content-Disposition", "attachment; filename=test.pdf"
        );
        using (var stringReader = new StringReader(xHtml))
        {
            using (Document document = new Document())
            {
                PdfWriter writer = PdfWriter.GetInstance(
                    document, Response.OutputStream
                );
                document.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(
                    writer, document, stringReader
                );
            }
        }
    
        return new EmptyResult();
    }
