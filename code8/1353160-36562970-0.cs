    string pdfTemplate = Server.MapPath(@"~\Pdf\132331.pdf");
    Response.ContentType = "application/pdf";
    Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName + ".pdf");
    Response.Clear();
    using (var memoryStream = new MemoryStream())
    {
        PdfReader pdfReader = new PdfReader(pdfTemplate);
        PdfStamper pdfStamper = new PdfStamper(pdfReader, memoryStream);
        pdfStamper.FormFlattening = true;
        iTextSharp.text.pdf.PdfContentByte pdfPage = pdfStamper.GetOverContent(1);
        AcroFields pdfFormFields = pdfStamper.AcroFields;
        //pdf stuff here
        memoryStream.CopyTo(Response.OutputStream); 
        pdfStamper.Close();               
    }
    Response.Flush();
