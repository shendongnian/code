    protected void save_pdf()
    {
       String path_name = "~/PDF/";
       var pdfPath = Path.Combine(Server.MapPath(path_name));
       var formFieldMap = PDFHelper.GetFormFieldNames(pdfPath);
    
       string username = "Test";
       string password = "12345";      
       String file_name_pdf = "Test.pdf";
    
       var pdfContents = PDFHelper.GeneratePDF(pdfPath, formFieldMap);
    
       File.WriteAllBytes(Path.Combine(pdfPath, file_name_pdf), pdfContents);
    
       WebRequest request = WebRequest.Create(Server.MapPath("~/PDF/" + pdfContents));
       request.Method = WebRequestMethods.Ftp.UploadFile;
    
       request.Credentials = new NetworkCredential(username, password);
       Stream reqStream = request.GetRequestStream();
       reqStream.Close();
    }
