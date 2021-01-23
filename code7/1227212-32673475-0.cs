    foreach (var item in Files)
    {
        
    FileUpload up = new FileUpload();
    up.PersonId = model.PersonId;
    up.FileName = System.IO.Path.GetFileName(item.FileName);
    up.MimeType = Files.ContentType;
    up.FileContent = item.Content;
    bll.AddFileUpload(up);
    }
