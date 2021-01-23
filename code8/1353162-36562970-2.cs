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
        memoryStream.CopyTo(Response.OutputStream);
    }
    
    Response.Flush();
