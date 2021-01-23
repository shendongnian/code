    foreach (var item in Files.Where(file => file != null && file.ContentLength > 0))
    {
        FileUpload up = new FileUpload
        {
             PersonId = model.PersonId,
             FileName = System.IO.Path.GetFileName(item.FileName),
             MimeType = item.ContentType,
             FileContent = item.Content,
         };
         bll.AddFileUpload(up);
    }
