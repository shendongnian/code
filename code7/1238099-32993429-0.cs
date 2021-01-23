    using(var stream = new System.IO.FileStream(filename,
                                                System.IO.FileMode.Open, 
                                                System.IO.FileAccess.Read))
    {
        try 
        {
           FilesResource.InsertMediaUpload request = service.Files.Insert(body, stream, mimeType);
           request.Upload();
           .
           .
           .
    }
