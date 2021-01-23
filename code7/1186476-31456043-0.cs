    //Create the PDF Document
    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
    
    //Bind a writer to our document abstraction and our output stream
    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
    //Open the document for writing
    pdfDoc.Open();
    
    //This next line is a syntax error
    //int pages = pdfDoc.;
    //Add the table to the PDF
    pdfDoc.Add(table);
    //Close the document
    pdfDoc.Close();
    //ASP.Net/HTTP stuff
    Response.ContentType = "application/pdf";
    Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    //Do not use this next line, it doesn't do what you think it does
    //Response.Write(pdfDoc);
    Response.End();
