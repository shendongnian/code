    string formFile = Server.MapPath("~/Template/CertificateTemplate.pdf")                                        
    string newFile = Server.MapPath("~/Certificates/"
    _dbRegistration.RegistrationNumber + ".pdf");
    
    PdfReader reader = new PdfReader(formFile);
    PdfStamper stamper = new PdfStamper(reader, new FileStream(
                            newFile, FileMode.Create));
    
    // You don't need this function here!
    // var pdfContentBuffer = stamper.GetOverContent(1);
    
    AcroFields fields = stamper.AcroFields;
    fields.SetField("ID", _dbRegistration.RegistrationNumber);
    ...
    ...
    stamper.FormFlattening = true;
    // You can't reuse a PdfReader object when you're using PdfStamper,
    // so let's create a new instance:
    PdfReader reader2 = new PdfReader(formFile);
    // Let's assume that your document only has one page,
    // and add a second page that has the same size as the first page:
    stamper.InsertPage(2, reader2.GetPageSize(1));
    // Now we get the PdfContentByte of that second page:
    var cb = stamper.GetOverContent(2);
    // And we add the content of the first page at position 0, 0
    cb.AddTemplate(stamper.GetImportedPage(reader2, 1), 0, 0);
    stamper.Close();
    // Don't forget to close the PdfReader instances!
    reader.Close();
    reader2.Close();
