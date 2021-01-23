    if (objControl.HasFile)
    {
       sSingleValue = Path.GetFileName(objControl.PostedFile.FileName);
       uploadFiles.Add(sColumnName, objControl);   
       contents = new byte[objControl.PostedFile.InputStream.Length];
       objControl.PostedFile.InputStream.Read(contents, 0, 
           (int)objControl.PostedFile.InputStream.Length);
    }
