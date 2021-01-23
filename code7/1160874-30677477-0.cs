    protected void ProcessRequest(HttpContext context)
    {
        byte[] pdfBytes = GetPdfBytes(); //This is where you should be calling the appropriate APIs to get the PDF as a stream of bytes
        var response = context.Response;
        response.ClearContent();
        response.ContentType = "application/pdf";
        response.AddHeader("Content-Disposition", "inline");
        response.AddHeader("Content-Length", pdfBytes.Length.ToString());
        response.BinaryWrite(pdfBytes); 
        response.End();
    }
