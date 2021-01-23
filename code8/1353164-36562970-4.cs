    string pdfTemplate = Server.MapPath(@"~\Pdf\132331.pdf");            
    Response.ContentType = "application/pdf";
    Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName + ".pdf");
    Response.Clear();
    using (var memoryStream = new MemoryStream())
    {
        using (PdfStamper pdfStamper = new PdfStamper(new PdfReader(pdfTemplate), memoryStream))
        {
            pdfStamper.FormFlattening = true;
            PdfContentByte pdfPage = pdfStamper.GetOverContent(1);
            AcroFields pdfFormFields = pdfStamper.AcroFields;                    
            // pdf stuff here                                    
        }
        // Memory stream is closed by PdfStamper, so we should read the inner buffer with ToArray()
        byte[] buffer = memoryStream.ToArray();
        Response.OutputStream.Write(buffer, 0, buffer.Length);
    }
    Response.Flush();
