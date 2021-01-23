    public void UploadFile(HttpPostedFileWrapper file)
    {
            // Ensure a file is present
            if(file != null)
            {
                // Store the file data 
                byte[] data = null;
                // Read the file data into an array
                using (var reader = new BinaryReader(file.InputStream))
                {
                    data = reader.ReadBytes(file.ContentLength);
                }
                // Call your service here, passing along the data and file name
                UploadFileViaService(file.FileName, data);
            }
    }
