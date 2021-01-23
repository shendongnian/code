    public JsonResult UploadValidationTable(HttpPostedFileBase csvFile)
    {
        CsvFileDescription inputFileDescription = new CsvFileDescription
        {
             SeparatorChar = ',',
             FirstLineHasColumnNames = true
        };
        
        var cc = new CsvContext();
        string filePath = uploadFile(csvFile.InputStream);
        var model = cc.Read<OutstandingCreditCsv>(filePath, inputFileDescription)
                    
        try
        {
            //do what you need here, like save items to database
        	var invoice = model.CreditInvoiceNumber;
        }
        catch(LINQtoCSVException ex)
        {
                        
        }
        
        return Json(model, "text/json");
    }
    
    private string uploadFile(Stream serverFileStream)
            {
                string directory = "~/Content/CSVUploads";
    
                bool directoryExists = System.IO.Directory.Exists(Server.MapPath(directory));
    
                if (!directoryExists)
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath(directory));
                }
    
                string targetFolder = Server.MapPath(directory);
                string filename = Path.Combine(targetFolder, Guid.NewGuid().ToString() + ".csv");
    
                try
                {
                    int length = 256; //todo: replace with actual length
                    int bytesRead = 0;
                    Byte[] buffer = new Byte[length];
    
                    // write the required bytes
                    using (FileStream fs = new FileStream(filename, FileMode.Create))
                    {
                        do
                        {
                            bytesRead = serverFileStream.Read(buffer, 0, length);
                            fs.Write(buffer, 0, bytesRead);
                        }
                        while (bytesRead == length);
                    }
    
                    serverFileStream.Dispose();
                    return filename;
                }
                catch (Exception ex)
                {
                    var message = ex.Message;
                    return string.Empty;
                }
            }
