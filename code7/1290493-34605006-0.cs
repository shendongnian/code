    var fileUploads = new List<FileUpload>
                          {
                              FileUploadImg1,
                              FileUploadImg2,
                              FileUploadImg3,
                              FileUploadImg4,
                              FileUploadImg5,
                          };
    var allowedExtensions = new List<string>{ ".jpg", ".jpeg", ".png" };
    foreach(FileUpload fileUpload in fileUploads)
    {
        if(!fileUpload.HasFile)
        {
            continue;
        }  
        
        if(allowedExtensions.Contains(System.IO.Path.GetExtension(fileUpload.FileName)))
        {
            // do stuff with valid file
        }
        else
        {
            // do stuff with invalid file
        }
    }
