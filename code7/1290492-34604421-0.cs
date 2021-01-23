    List<string> fileExtentions = new List<string>();
    
    if (FileUploadImg1.HasFile)
       fileExtentions.Add(System.IO.Path.GetExtension(FileUploadImg1.FileName));
    
    if (FileUploadImg2.HasFile)
       fileExtentions.Add(System.IO.Path.GetExtension(FileUploadImg2.FileName));
    
    if (FileUploadImg3.HasFile)
       fileExtentions.Add(System.IO.Path.GetExtension(FileUploadImg3.FileName));
    
    if (FileUploadImg4.HasFile)
       fileExtentions.Add(System.IO.Path.GetExtension(FileUploadImg4.FileName));
    
    if (FileUploadImg5.HasFile)
       fileExtentions.Add(System.IO.Path.GetExtension(FileUploadImg5.FileName));
    
    if(fileExtentions.Any(f=>!f.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                             !f.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) &&
                             !f.Equals(".png", StringComparison.OrdinalIgnoreCase))
    {
       //Invalid file format detected
    }
