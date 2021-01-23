    string pdfTemplate = Server.MapPath(@"~\Pdf\132331.pdf");
     
    Response.ContentType = "application/pdf";
    Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName + ".pdf");
    Response.Clear();
    using (PdfReader pdfReader = new PdfReader(pdfTemplate))
    {
        using (var memoryStream = new MemoryStream())
        {
            using (PdfStamper pdfStamper = new PdfStamper(pdfReader, memoryStream))
            {
                pdfStamper.FormFlattening = true;
                PdfContentByte pdfPage = pdfStamper.GetOverContent(1);
                AcroFields pdfFormFields = pdfStamper.AcroFields;
                    
                // pdf stuff here
                    
                // Need to close the PdfStamper before writing the content of the memory stream to the response
                pdfStamper.Close();                        
            }
            memoryStream.CopyTo(Response.OutputStream);
        }
    }
    Response.Flush();
